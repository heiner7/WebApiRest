﻿using System;
using System.Collections.Generic;

namespace Abstraction
{
    public interface ICrud<T>
    {
        T Save(T entity);
        IList<T> GetAll(int id);
        IList<T> GetByState(bool estado);
        void Delete(int id);
    }

    public interface IGetPage<T>
    {
        IEnumerable<T> GetPage(IEnumerable<T> collection, int pageNumber, int resultsPage);
    }
}
