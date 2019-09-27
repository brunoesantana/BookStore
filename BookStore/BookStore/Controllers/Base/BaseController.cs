﻿using BookStore.Business.Interface.Base;
using BookStore.CrossCutting.DTO.Base;
using BookStore.CrossCutting.Exceptions;
using BookStore.CrossCutting.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Controllers.Base
{
    public class BaseController<T, TDto, TInsertDto, TUpdateDto> : ControllerBase where T : class where TDto : class where TInsertDto : class where TUpdateDto : BaseUpdateDTO
    {
        protected readonly IServiceBase<T> _service;

        public BaseController(IServiceBase<T> baseService)
        {
            _service = baseService;
        }

        protected ActionResult Add(TInsertDto dto)
        {
            if (!ModelState.IsValid)
                throw new EntityValidationException();

            var entity = MapperHelper.Map<TInsertDto, T>(dto);
            var response = _service.Create(entity);

            return Ok(response);
        }

        protected ActionResult Update(Guid id, TUpdateDto dto)
        {
            if (!ModelState.IsValid)
                throw new EntityValidationException();

            dto.Id = id;
            var entity = MapperHelper.Map<TUpdateDto, T>(dto);
            var response = _service.Update(entity);

            return Ok(response);
        }

        protected ActionResult Delete(Guid id)
        {
            _service.Remove(id);
            return Ok();
        }

        protected ActionResult Find(Guid id)
        {
            var response = _service.Find(id);

            if (response == null)
                return NotFound();

            return Ok(MapperHelper.Map<T, TDto>(response));
        }

        protected ActionResult GetAll()
        {
            var response = _service.GetAll();
            return response.Any() ? Ok(MapperHelper.Map<List<T>, List<TDto>>(response)) : throw new NotFoundException();
        }
    }
}
