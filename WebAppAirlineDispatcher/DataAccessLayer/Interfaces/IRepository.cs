using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity entity);
        void Update();
        void Delete(TEntity entity);
        void DeleteAll();

    }
}
