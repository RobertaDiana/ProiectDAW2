using Demo.Models.DTOs.Producator;
using Demo.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW2.Helpers.Attributes;
using ProiectDAW2.Servicies;

namespace ProiectDAW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IProducatorService _producatorService;

        public AuthController(IProducatorService producatorService)
        {
            _producatorService = producatorService;
        }


        [HttpPost("create-user")]
        public async Task<IActionResult> CreateProducator(ProducatorAuthRequestDto producator)
        {
            var producatorToCreate = new producator
            {

                NumeProducator = producator.NumeProducator,
                DataVenirii = producator.DataVenirii,
                Role = Role.Admin,
                Email = producator.Email,
                PasswordHash = BCryptNet.HashPassword(producator.Password)
            };

            await _producatorService.Create(producatorToCreate);
            return Ok();
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(ProducatorAuthRequestDto producator)
        {
            var producatorToCreate = new producator
            {
                
                NumeProducator = producator.NumeProducator,
                DataVenirii = producator.DataVenirii,
                Role = Role.Admin,
                Email = producator.Email,
                PasswordHash = BCryptNet.HashPassword(producator.Password)
            };

            await _producatorService.Create(producatorToCreate);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(ProducatorAuthRequestDto producator)
        {
            var response = _producatorService.Authentificate(producator);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok();
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public IActionResult GetAllAdmin()
        {
            var producator = _producatorService.GetAllProducatori();
            return Ok(producatori);
        }

        [Authorization(Role.Producator)]
        [HttpGet("user")]
        public IActionResult GetAllProducatori()
        {
            return Ok("User");
        }
       
    }
}
