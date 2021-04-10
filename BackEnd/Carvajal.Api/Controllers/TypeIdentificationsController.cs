using AutoMapper;
using Carvajal.Api.Dtos;
using Carvajal.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Carvajal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdentificationsController : ControllerBase
    {
        private readonly ITypeIdentificationRepository _repository;
        private readonly IMapper _mapper;

        public TypeIdentificationsController(ITypeIdentificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(_mapper.Map<IEnumerable<TypeIdentificationDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}