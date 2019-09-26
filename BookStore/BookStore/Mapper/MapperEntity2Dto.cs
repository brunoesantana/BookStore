using BookStore.CrossCutting.DTO.Book;
using BookStore.CrossCutting.DTO.User;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Mapper
{
    public class MapperEntity2Dto
    {
        public MapperEntity2Dto()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
