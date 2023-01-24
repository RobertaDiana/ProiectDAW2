using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs;
using Demo.Repositories.ProdusRepository;

namespace ProiectDAW2.Servicies
{
    public class ProduseServicies : IProduseServicies

    {
        public IProduseRepository _produseRepository;
        public IMapper _mapper;

        public ProduseServicies(IProduseRepository produseRepository, IMapper mapper)
        {
            _produseRepository = produseRepository;
            _mapper = mapper;
        }

        public async Task<List<ProduseDto>> GetAllProduse()
        {
            var produse = await _produseRepository.GetAllAsync();
            List<ProduseDto> result = _mapper.Map<List<ProduseDto>>(produse);
            return result;
        }

        public async Task AddProduse(ProduseDto newProduse)
        {
            var newDbProduse = _mapper.Map<Produse>(newProduse);
            await _produseRepository.CreateAsync(newDbProduse);
            await _produseRepository.SaveAsync();
        }

        public async Task DeleteProduse(Guid produseId)
        {
            var produseToDelete = await _produseRepository.FindByIdAsync(produseId);
            _produseRepository.Delete(produseToDelete);
            await _produseRepository.SaveAsync();
        }
    }
}
