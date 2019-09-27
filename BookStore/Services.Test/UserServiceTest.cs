using BookStore.Api.Mapper;
using BookStore.Business;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.User;
using BookStore.CrossCutting.Helper;
using BookStore.Data.Context;
using BookStore.Data.Interface;
using BookStore.Data.Repository;
using BookStore.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Services.Test
{
    public class UserServiceTest
    {
        private const string SENHA = "12345";

        private IUserService _userService;
        private IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _userRepository = new UserRepository(new DataContext());
            _userService = new UserService(_userRepository);
        }

        [Test]
        public void Deve_inserir_registro_de_usuario_corretamente()
        {
            var response = InsertUser();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_usuarios_corretamente()
        {
            InsertUser();

            var list = _userService.GetAll();
            Assert.IsTrue(list.Any());

            var user = list.FirstOrDefault();
            var response = _userService.Find(user.Id);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_usuarios_corretamente()
        {
            var userGuid = InsertUser();
            var user = _userService.Find(userGuid);
            var version = user.Version;
            var dto = UpdateUserDTO(user);

            var response = _userService.Update(MapperHelper.Map<UserUpdateDTO, User>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_usuarios_corretamente()
        {
            var userGuid = InsertUser();
            var book = _userService.Find(userGuid);

            Assert.IsNotNull(book);

            _userService.Remove(book.Id);

            var response = _userService.GetAll().FirstOrDefault(f => f.Id.Equals(book.Id));

            Assert.IsNull(response);
        }

        [Test]
        public void Deve_logar_corretamente()
        {
            InsertUser();

            var user = _userService.GetAll().FirstOrDefault(f => f.Active);
            var userResponse = _userService.Login(user.UserName, EncryptHelper.EncryptPassword(SENHA));

            Assert.IsNotNull(userResponse);
        }

        private Guid InsertUser()
        {
            var dto = GetUserInsertDTO();
            return _userService.Create(MapperHelper.Map<UserInsertDTO, User>(dto));
        }

        private UserInsertDTO GetUserInsertDTO()
        {
            return new UserInsertDTO
            {
                Username = $"usuario{TestHelper.GetRandomNumber()}",
                Password = "12345"
            };
        }

        private UserUpdateDTO UpdateUserDTO(User user)
        {
            return new UserUpdateDTO
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }
    }
}