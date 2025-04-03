using Application.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<RegisterDto> _validator;

        public AuthController(IValidator<RegisterDto> validator)
        {
            _validator = validator;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var result = _validator.Validate(registerDto);
            if (!result.IsValid)
            {
                registerDto.Message = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                return BadRequest(registerDto.Message);
            }
            return Ok(registerDto);
        }

    }
}
