using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T entity);
        void Edit(T entity);
        void Remove(int id);
    }
}