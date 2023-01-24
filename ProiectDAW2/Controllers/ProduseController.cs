using Demo.Models.DTOs;
using Demo.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW2.Helpers.Attributes;
using ProiectDAW2.Servicies;

namespace ProiectDAW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduseController : ControllerBase
    {
        public readonly IProduseServicies _produseService;
        public ProduseController(IProduseServicies produseService)
        {
            _produseService = produseService;
        }

        [HttpGet]
        [Authorization(Role.User, Role.Admin)]
        public async Task<IActionResult>GetAllProduse()
        {
            return Ok(await _produseService.GetAllProduse());

        }

        [HttpPost]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> AddProduse(ProduseDto newProduse)
        {
            await _produseService.AddProduse(newProduse);
            return Ok();
        }

        [HttpDelete("{produseId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteProduse([FromRoute] Guid produsId)
        {
            await _produseService.DeleteProduse(produsId);
            return Ok(await _produseService.GetAllProduse());
        }
    }
}
