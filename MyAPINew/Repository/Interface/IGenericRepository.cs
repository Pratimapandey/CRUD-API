using System.Collections.Generic;

namespace MyAPINew.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
