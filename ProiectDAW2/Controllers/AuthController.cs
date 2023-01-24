using Demo.Models;
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


        [HttpPost("createUser")]
        public async Task<IActionResult> CreateProducator(ProducatorAuthRequestDto producator)
        {
            await _producatorService.Create(producator, Role.User);
            return Ok();
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(ProducatorAuthRequestDto producator)
        {
            await _producatorService.Create(producator, Role.Admin);
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

        //[Authorization(Role.Admin, Role.User)]
        [HttpGet("getProducator/{producatorId}")]
        public async Task<IActionResult> GetAllProducatori([FromRoute] Guid producatorId)
        {
            var producatori = await _producatorService.GetProducator(producatorId);
            return Ok(producatori);
        }

        [HttpPut("updateProducator")]
        public async Task<IActionResult> UpdateProducator(UpdateProducatorDto updateProducator)
        {
            await _producatorService.UpdateProducator(updateProducator);
            return Ok();
        }

        [HttpDelete("delete/{producatorId}")]
        public async Task<IActionResult> DeleteProducator([FromRoute] Guid producatorId)
        {
            await _producatorService.DeleteProducator(producatorId);
            return Ok();
        }
    }
}
