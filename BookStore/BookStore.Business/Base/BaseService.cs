using BookStore.Business.Interface.Base;
using BookStore.CrossCutting.Exceptions;
using BookStore.Data.Interface.Base;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Base
{
    public class BaseService<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepositoryBase<T> Repository;

        public BaseService(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        public virtual Guid Create(T dto)
        {
            return Repository.Create(dto);
        }

        public virtual T Update(T dto)
        {
            return Repository.Update(dto);
        }

        public virtual void Remove(Guid id)
        {
            if(Find(id) == null)
                throw new NotFoundException();

            Repository.Remove(id);
        }

        public virtual T Find(Guid id)
        {
            return Repository.Find(id) ?? throw new NotFoundException();
        }

        public virtual List<T> GetAll()
        {
            return Repository.GetAll();
        }
    }
}
