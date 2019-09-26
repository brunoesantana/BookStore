using BookStore.CrossCutting.DTO.Book;
using BookStore.CrossCutting.DTO.User;
using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Mapper
{
    public class MapperDto2Entity : Profile
    {
        public MapperDto2Entity()
        {
            CreateMap<BookInsertDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();

            CreateMap<UserInsertDTO, User>()
                .ForMember(to => to.Password, map => map.MapFrom(from => from.Password.EncryptPassword()));

            CreateMap<UserUpdateDTO, User>();
        }
    }
}
