using AutoMapper;
using BookStore.CrossCutting.DTO.Book;
using BookStore.CrossCutting.DTO.User;
using BookStore.Domain;

namespace BookStore.Api.Mapper
{
    public class MapperEntity2Dto : Profile
    {
        public MapperEntity2Dto()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
