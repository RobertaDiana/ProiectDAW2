using Demo.Models.DTOs;

namespace ProiectDAW2.Servicies
{
    public interface ICategorieService
    {
        public Task<List<CategorieDto>> GetAll();
        public Task AddCategorie(CategorieDto newCategorie);
        public Task UpdateCategorie(CategorieDto newCategorie);
        Task DeleteCategorie(Guid categorieId);
    }
}