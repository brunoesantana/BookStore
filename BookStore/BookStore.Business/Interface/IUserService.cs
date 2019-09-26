using BookStore.Business.Interface.Base;
using BookStore.Domain;

namespace BookStore.Business.Interface
{
    public interface IUserService : IServiceBase<User>
    {
        User Login(string login, string password);
    }
}
