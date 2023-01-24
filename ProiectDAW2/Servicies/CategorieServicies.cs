using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs.Categorie;
using Demo.Models.DTOs.ProdusInCategorie;
using Demo.Repositories.CategorieRepository;
using Demo.Repositories.ProduseInCategorieRepository;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ProiectDAW2.Servicies
{
    public class CategorieServicies : ICategorieService
    {
        public ICategorieRepository _categorieRepository;
        public IProduseInCategorieRepository _produseInCategorieRepository;
        public IMapper _mapper;

        public CategorieServicies(ICategorieRepository categorieRepository, IProduseInCategorieRepository produseInCategorieRepository, IMapper mapper)
        {
            _categorieRepository = categorieRepository;
            _produseInCategorieRepository = produseInCategorieRepository;
            _mapper = mapper;
        }

        public async Task AddCategorie(CategorieDto newCategorie)
        {
            var newDbCategorie = _mapper.Map<Categorie>(newCategorie);
            newDbCategorie.DateCreated = DateTime.Now;

            await _categorieRepository.CreateAsync(newDbCategorie);
            await _categorieRepository.SaveAsync();
        }

        public async Task UpdateCategorie(UpdateCategorieDto updateCategorie)
        {
            var oldCategorie = await _categorieRepository.FindByIdAsync(updateCategorie.Id);
            if(oldCategorie == null)
            {
                throw new Exception("Categoria cu id-ul dat nu exista");
            }

            oldCategorie.Denumire = updateCategorie.Denumire;
            oldCategorie.Numar = updateCategorie.Numar;
            oldCategorie.DateModified = DateTime.Now;

            _categorieRepository.Update(oldCategorie);
            await _categorieRepository.SaveAsync();
        }

        public async Task DeleteCategorie(Guid categorieId)
        {
            var categorieToDelete = await _categorieRepository.FindByIdAsync(categorieId);
            if (categorieToDelete == null)
            {
                throw new Exception("Categoria cu id-ul dat nu exista");
            }

            _categorieRepository.Delete(categorieToDelete);
            await _categorieRepository.SaveAsync();
        }

        public async Task<List<CategorieDto>> GetAll()
        {
            var categorii = await _categorieRepository.GetAllAsync();
            return _mapper.Map<List<CategorieDto>>(categorii);
        }

        public async Task AddProdusToCategorie(ProdusInCategorieDto produsInCategorie)
        {
            var newProdusInCategorie = new ProduseInCategorie
            {
                ProduseId = produsInCategorie.ProdusId,
                CategorieId = produsInCategorie.CategorieId
            };

            await _produseInCategorieRepository.CreateAsync(newProdusInCategorie);
            await _produseInCategorieRepository.SaveAsync();
        }
    }
}
