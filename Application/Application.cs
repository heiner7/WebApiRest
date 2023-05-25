using Abstraction;
using ApiRest.Abstraction;
using Repository;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface IApplication<T> : ICrud<T>
    {

    }
    public class Application<T> : IApplication<T> where T: IEntity
    {
        IRepository<T> _repository;
        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll(int id)
        {
            return _repository.GetAll(id);
        }

        public IList<T> GetByState(bool estado)
        {
            return _repository.GetByState(estado);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}
