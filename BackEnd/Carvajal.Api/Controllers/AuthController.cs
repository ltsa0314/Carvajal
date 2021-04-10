using System;
using Carvajal.Api.Dtos;
using Carvajal.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carvajal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                if (!_repository.ValidateUserPassword(dto.Identification , dto.Password))
                {
                    throw new ArgumentException("Credenciales Invalidas");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}