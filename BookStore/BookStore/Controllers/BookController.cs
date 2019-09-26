using System;
using System.Net;
using BookStore.Api.Controllers.Base;
using BookStore.Business.Interface;
using BookStore.CrossCutting.DTO.Book;
using BookStore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/v1/books")]
    public class BookController : BaseController<Book, BookDTO, BookInsertDTO, BookUpdateDTO>
    {
        public BookController(IBookService baseService) : base(baseService)
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
        public new ActionResult Add([FromBody] BookInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] BookUpdateDTO model)
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
