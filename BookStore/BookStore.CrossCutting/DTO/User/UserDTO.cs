using System;

namespace BookStore.CrossCutting.DTO.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}
