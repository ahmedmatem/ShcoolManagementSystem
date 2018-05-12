using AMA.SchoolManagementSystem.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMA.SchoolManagementSystem.Data.Repositories
{
    public class EfRepository<T> : IEfRepository<T>
        where T : class, IDeletable
    {
        public EfRepository(MsSqlDbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", 
                nameof(context));
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        //public T GetById(int id)
        //{
        //    return this.All().FirstOrDefault(x => x.Id == id);
        //}

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if(entry.State != EntityState.Detached){
                entry.State = EntityState.Added;
            }
            else
            {
                this.Context.Set<T>().Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if(entry.State == EntityState.Deleted)
            {
                this.Context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        //public void HardDelete(T entity)
        //{
        //    this.DbSet.Remove(entity);
        //}

        //public void Save()
        //{
        //    this.Context.SaveChanges();
        //}
    }
}
