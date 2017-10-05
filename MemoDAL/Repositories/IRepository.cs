using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoDAL.Repositories
{
	public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        //IEnumerable<T> GetCollectionByPredicate(Func<T, Boolean> predicate);
        //T GetOneElementOrDefault(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
