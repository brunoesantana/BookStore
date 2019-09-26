﻿using BookStore.Api.Controllers.Base;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.User;
using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/v1/users")]
    public class UserController : BaseController<User, UserDTO, UserInsertDTO, UserUpdateDTO>
    {
        public UserController(IUserService baseService) : base(baseService)
        {
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult GetAll()
        {
            return base.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Get(Guid id)
        {
            return base.Find(id);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Add([FromBody] UserInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] UserUpdateDTO model)
        {
            return base.Update(id, model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
