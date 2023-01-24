using Demo.Models.DTOs.Produs;
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

        [HttpGet("getToateProduseleOrdonate")]
        //[Authorization(Role.User, Role.Admin)]
        public async Task<IActionResult> GetAllProduse()
        {
            return Ok(await _produseService.GetAllProduse());
        }

        [HttpGet("getProduseInTermenCuProducatori")]
        //[Authorization(Role.User, Role.Admin)]
        public async Task<IActionResult> GetProduseInTermenCuProducatori()
        {
            return Ok(await _produseService.GetProduseInTermenCuProducatori());
        }

        [HttpGet("getNrProduseProducatori")]
        //[Authorization(Role.User, Role.Admin)]
        public async Task<IActionResult> GetNrProduseProducatori()
        {
            return Ok(await _produseService.GetCantitateProducatori());
        }

        [HttpPost("createProdus")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> AddProdus(ProdusDto newProdus)
        {
            await _produseService.AddProduse(newProdus);
            return Ok();
        }

        [HttpPut("updateProdus")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateProdus(UpdateProdusDto updateProdus)
        {
            await _produseService.UpdateProdus(updateProdus);
            return Ok();
        }

        [HttpDelete("delete/{produsId}")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteProduse([FromRoute] Guid produsId)
        {
            await _produseService.DeleteProduse(produsId);
            return Ok();
        }
    }
}
