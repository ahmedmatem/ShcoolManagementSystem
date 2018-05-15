namespace AMA.SchoolManagementSystem.Data
{
    using AMA.SchoolManagementSystem.Data.Model;
    using AMA.SchoolManagementSystem.Data.Model.Abstracts;
    using AMA.SchoolManagementSystem.Data.Model.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<School> Schools { get; set; }

        public IDbSet<Principal> Principals { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Teacher> Teachers { get; set; }

        public IDbSet<Discipline> Disciplines { get; set; }

        public IDbSet<Group> Groups { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOptional(t => t.Group)
                .WithRequired(g => g.Teacher);

            modelBuilder.Entity<ERegister>()
                .HasRequired(x => x.School)
                .WithRequiredPrincipal(x => x.ERegister);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
