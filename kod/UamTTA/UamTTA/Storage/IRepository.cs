using System.Collections.Generic;
using UamTTA.Model;

namespace UamTTA.Storage
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T FindById(int id);

        T Persist(T item);

        void Remove(T item);
    }
}