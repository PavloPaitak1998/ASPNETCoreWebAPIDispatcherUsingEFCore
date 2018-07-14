using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Implementation.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected readonly DispatcherContext Context;
        private DbSet<TEntity> entities;

        public Repository(DispatcherContext context)
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public virtual void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            SaveChange();
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            var res = entities.Where(predicate);
            return res.ToList();
        }

        public virtual void Update()
        {
            SaveChange();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            SaveChange();
        }

        public virtual void DeleteAll()
        {
            entities.RemoveRange(entities);
            SaveChange();
        }

        private void SaveChange()
        {
            Context.SaveChanges();
        }
    }
}
