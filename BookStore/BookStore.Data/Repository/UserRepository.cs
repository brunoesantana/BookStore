using BookStore.Data.Base;
using BookStore.Data.Context;
using BookStore.Data.Interface;
using BookStore.Domain;
using System.Linq;

namespace BookStore.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User Login(string login, string password)
        {
            using (var context = GetContext())
            {
                return context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login) && w.Password.Equals(password));
            }
        }

        public User FindByLogin(string login)
        {
            using (var context = GetContext())
            {
                return context.Set<User>().FirstOrDefault(w => w.UserName.Equals(login));
            }
        }
    }
}
