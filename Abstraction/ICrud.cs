using System;
using System.Collections.Generic;

namespace Abstraction
{
    public interface ICrud<T>
    {
        T Save(T entity);
        IList<T> GetAll();
        IList<T> GetProcedure();
        T GetById(int id);
        void Delete(int id);
    }
}
