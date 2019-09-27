using BookStore.Api.Auth;
using BookStore.Api.Controllers.Base;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.Base;
using BookStore.CrossCutting.DTO.Login;
using BookStore.CrossCutting.Helper;
using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/v1/login")]
    public class LoginController : BaseController<User, LoginDTO, LoginDTO, BaseUpdateDTO>
    {
        private readonly IUserService _userService;

        public LoginController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            var login = _userService.Login(dto.Login, EncryptHelper.EncryptPassword(dto.Password));
            var token = UserManagement.RegisterUser(login);

            return Ok(token);
        }
    }
}