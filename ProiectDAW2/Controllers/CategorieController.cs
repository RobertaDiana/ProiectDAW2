using Demo.Models;
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
    public class CategorieController : ControllerBase
    {
        public readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet]
        [Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categorieService.GetAll());
        }

        [HttpPost]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> AddCategorie(CategorieDto newCategorie)
        {
            await _categorieService.AddCategorie(newCategorie);
            return Ok();
        }

        //[HttpPost("{categorieId}")]
        //[Authorization(Role.Admin, Role.User)]
        //public async Task<IActionResult> AddProduseToCategorie([FromRoute] Guid categorieId, [FromBody] List<Guid> produseIds)
        //{
        //    return Ok(await _categorieService.AddProduseToCategorie(categorieId, produseIds));
        //}

        

        [HttpDelete("{categorieId}")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteCategorie([FromRoute] Guid categorieId)
        {
            await _categorieService.DeleteCategorie(categorieId);
            return Ok(await _categorieService.GetAll());
        }
    }
}
