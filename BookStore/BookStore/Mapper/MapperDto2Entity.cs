using AutoMapper;
using BookStore.CrossCutting.DTO.Book;
using BookStore.CrossCutting.DTO.User;
using BookStore.CrossCutting.Helper;
using BookStore.Domain;

namespace BookStore.Api.Mapper
{
    public class MapperDto2Entity : Profile
    {
        public MapperDto2Entity()
        {
            CreateMap<BookInsertDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();

            CreateMap<UserInsertDTO, User>()
                .ForMember(to => to.Password, map => map.MapFrom(from => EncryptHelper.EncryptPassword(from.Password)));

            CreateMap<UserUpdateDTO, User>();
        }
    }
}
