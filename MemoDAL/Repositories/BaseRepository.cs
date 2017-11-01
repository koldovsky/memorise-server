using MemoDAL.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MemoDAL.Repositories
{
    public abstract class BaseRepository<T> :
        IRepository<T> where T : Entities.BaseEntity
    {
        private DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public MemoContext MemoContext
        {
            get { return context as MemoContext; }
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Create(T obj)
        {
            context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Get(id));
        }
    }
}