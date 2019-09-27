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
            var dto = GetUserInsertDTO();
            var response = _userService.Create(MapperHelper.Map<UserInsertDTO, User>(dto));

            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_logar_corretamente()
        {
            var dto = GetUserInsertDTO();

            _userService.Create(MapperHelper.Map<UserInsertDTO, User>(dto));

            var user = _userService.GetAll().FirstOrDefault(f => f.Active);
            var userResponse = _userService.Login(user.UserName, EncryptHelper.EncryptPassword(SENHA));

            Assert.IsNotNull(userResponse);
        } 

        private UserInsertDTO GetUserInsertDTO()
        {
            return new UserInsertDTO
            {
                Username = $"usuario{TestHelper.GetRandomNumber()}",
                Password = "12345"
            };
        }
    }
}