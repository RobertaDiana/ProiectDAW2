using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllProduse()
        {
            return Ok(_produseService.GetAllProduse());

        }

    }
}
