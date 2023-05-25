using Abstraction;
using ApiRest.Abstraction;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public interface IApplication<T> : ICrud<T>, IGetPage<T>
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

        public IEnumerable<T> GetPage(IEnumerable<T> collection, int pageNumber, int resultsPage)
        {
            int startIndex = (pageNumber - 1) * resultsPage;
            return collection.Skip(startIndex).Take(resultsPage);
        }
    }
}
