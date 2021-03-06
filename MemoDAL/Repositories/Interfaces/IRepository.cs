﻿using MemoDAL.Entities;
using System.Collections.Generic;

namespace MemoDAL.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
