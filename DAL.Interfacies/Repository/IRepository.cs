using System.Collections.Generic;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetById(int key);
        void Create(TEntity e);
        void Delete(TEntity e);
        IEnumerable<TEntity> GetAll();
    }
}