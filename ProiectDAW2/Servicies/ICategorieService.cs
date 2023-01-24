using Demo.Models.DTOs.Categorie;
using Demo.Models.DTOs.ProdusInCategorie;

namespace ProiectDAW2.Servicies
{
    public interface ICategorieService
    {
        Task<List<CategorieDto>> GetAll();
        Task AddCategorie(CategorieDto newCategorie);
        Task UpdateCategorie(UpdateCategorieDto updateCategorie);
        Task DeleteCategorie(Guid categorieId);
        Task AddProdusToCategorie(ProdusInCategorieDto produsInCategorie);
    }
}