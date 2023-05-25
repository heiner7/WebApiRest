using Abstraction;
using ApiRest.Abstraction;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> : ICrud<T>
    {

    }
    public class Repository<T> : IRepository<T> where T: IEntity
    {
        IDbContext<T> _ctx;
        public Repository(IDbContext<T> ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int id)
        {
            _ctx.Delete(id);
        }

        public IList<T> GetAll(int id)
        {
            return _ctx.GetAll(id);
        }

        public IList<T> GetByState(bool estado)
        {
            return _ctx.GetByState(estado);
        }

        public T Save(T entity)
        {
            return _ctx.Save(entity);
        }
    }
}
