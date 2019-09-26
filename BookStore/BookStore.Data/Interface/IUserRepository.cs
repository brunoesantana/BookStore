using BookStore.Data.Interface.Base;
using BookStore.Domain;

namespace BookStore.Data.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Login(string login, string password);
        User FindByLogin(string login);
    }
}
