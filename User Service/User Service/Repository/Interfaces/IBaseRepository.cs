namespace User_Service.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }

}
