using System;
using System.Collections.Generic;

namespace BookStore.Data.Interface.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Guid Create(T dto);

        T Update(T dto);

        void Remove(Guid id);

        T Find(Guid id);

        List<T> GetAll();
    }
}
