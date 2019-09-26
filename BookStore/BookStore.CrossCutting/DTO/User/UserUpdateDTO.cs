using BookStore.CrossCutting.DTO.Base;

namespace BookStore.CrossCutting.DTO.User
{
    public class UserUpdateDTO : BaseUpdateDTO
    {
        public string UserName { get; set; }
    }
}
