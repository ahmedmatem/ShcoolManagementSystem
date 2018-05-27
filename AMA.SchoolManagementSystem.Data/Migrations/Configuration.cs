namespace AMA.SchoolManagementSystem.Data.Migrations
{
    using AMA.SchoolManagementSystem.Data.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AMA.SchoolManagementSystem.Data.MsSqlDbContext>
    {

        const string AdministrationUserName = "ahmed@matem.com";

        const string AdministrationPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AMA.SchoolManagementSystem.Data.MsSqlDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(Data.MsSqlDbContext context)
        {

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "SuperAdmin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministrationUserName, Email = AdministrationUserName, EmailConfirmed = true };
                userManager.Create(user, AdministrationPassword);

                userManager.AddToRole(user.Id, "SuperAdmin");
            }
        }
    }
}
