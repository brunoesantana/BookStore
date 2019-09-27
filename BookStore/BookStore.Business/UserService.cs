using BookStore.Business.Base;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.User;
using BookStore.CrossCutting.Exceptions;
using BookStore.CrossCutting.Helper;
using BookStore.Data.Interface;
using BookStore.Domain;
using System;

namespace BookStore.Business
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public override Guid Create(User dto)
        {
            var user = ((IUserRepository)Repository).FindByLogin(dto.UserName);

            if (user != null && !user.Active)
                throw new NotFoundException();

            return base.Create(dto);
        }

        public override User Update(User dto)
        {
            var user = ((IUserRepository)Repository).Find(dto.Id);
            dto.Password = user.Password;

            return base.Update(dto);
        }

        public User Login(string login, string password)
        {
            var user = ((IUserRepository)Repository).Login(login, password);
            return user ?? throw new NotFoundException();
        }
    }
}