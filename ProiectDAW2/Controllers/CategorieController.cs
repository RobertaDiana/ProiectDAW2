using Demo.Models;
using Demo.Models.DTOs.Categorie;
using Demo.Models.DTOs.ProdusInCategorie;
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

        [HttpGet("getToateCategoriile")]
        //[Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categorieService.GetAll());
        }

        [HttpPost("createCategorie")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> AddCategorie(CategorieDto newCategorie)
        {
            await _categorieService.AddCategorie(newCategorie);
            return Ok();
        }

        [HttpPost("adaugaProdusLaCategorie")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> AddProdusToCategorie(ProdusInCategorieDto produsInCategorie)
        {
            await _categorieService.AddProdusToCategorie(produsInCategorie);
            return Ok();
        }

        [HttpPut("updateCategorie")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateCategorie(UpdateCategorieDto updateCategorie)
        {
            await _categorieService.UpdateCategorie(updateCategorie);
            return Ok();
        }

        [HttpDelete("delete/{categorieId}")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteCategorie([FromRoute] Guid categorieId)
        {
            await _categorieService.DeleteCategorie(categorieId);
            return Ok();
        }
    }
}
