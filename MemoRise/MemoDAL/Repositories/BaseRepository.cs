using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public abstract class BaseRepository<T>:
        IRepository<T> where T:Entities.BaseEntity
    {
        private DbContext Context;

        public BaseRepository(DbContext context)
        {
            this.Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetCollectionByPredicate(Func<T, Boolean> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T GetOneElementOrDefault(Func<T, Boolean> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public void Create(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
        }

        public MemoContext MemoContext
        {
            get { return Context as MemoContext; }
        }
    }
}