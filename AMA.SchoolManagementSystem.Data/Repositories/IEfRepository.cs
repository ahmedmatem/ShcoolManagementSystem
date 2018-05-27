namespace AMA.SchoolManagementSystem.Data.Repositories
{
    using System;
    using System.Linq;

    using AMA.SchoolManagementSystem.Data.Model.Contracts;

    public interface IEfRepository<T> 
        where T : class, IDeletable
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        //void HardDelete(T entity);

        //void Save();
    }
}
