using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs;
using Demo.Repositories.CategorieRepository;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ProiectDAW2.Servicies
{
    public class CategorieServicies : ICategorieService
    {
        public ICategorieRepository _categorieRepository;
        public IMapper _mapper;

        public CategorieServicies(ICategorieRepository categorieRepository, IMapper mapper)
        {
            _categorieRepository = categorieRepository;
            _mapper = mapper;
        }

        public async Task AddCategorie(CategorieDto newCategorie)
        {
            var newDbCategorie = _mapper.Map<Categorie>(newCategorie);
            await _categorieRepository.CreateAsync(newDbCategorie);
            await _categorieRepository.SaveAsync();
        }
        public async Task UpdateCategorie(CategorieDto categorie)
        {

        }
        public async Task DeleteCategorie(Guid categorieId)
        {
            var categorieToDelete = await _categorieRepository.FindByIdAsync(categorieId);
            _categorieRepository.Delete(categorieToDelete);
            await _categorieRepository.SaveAsync();
        }

        public async Task<List<CategorieDto>> GetAll()
        {
            var categorii = await _categorieRepository.GetAllAsync();
            return _mapper.Map<List<CategorieDto>>(categorii);
        }
    }
}
