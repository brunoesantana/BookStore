using BookStore.Domain.Base;

namespace BookStore.Domain
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
