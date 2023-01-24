using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs.Produs;
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

        public async Task<List<ProdusDto>> GetAllProduse()
        {
            var produse = await _produseRepository.GetAllProduseOrdonate();
            List<ProdusDto> result = _mapper.Map<List<ProdusDto>>(produse);
            return result;
        }

        public async Task<List<ProdusCuProducatorDto>> GetProduseInTermenCuProducatori()
        {
            var produseCuProducatori = await _produseRepository.GetProduseInTermenCuProducatori();
            List<ProdusCuProducatorDto> result = _mapper.Map<List<ProdusCuProducatorDto>>(produseCuProducatori);
            return result;
        }

        public async Task AddProduse(ProdusDto newProduse)
        {
            var newDbProduse = _mapper.Map<Produse>(newProduse);

            newDbProduse.DateCreated = DateTime.Now;

            await _produseRepository.CreateAsync(newDbProduse);
            await _produseRepository.SaveAsync();
        }

        public async Task DeleteProduse(Guid produseId)
        {
            var produseToDelete = await _produseRepository.FindByIdAsync(produseId);
            if (produseToDelete == null)
            {
                throw new Exception("Produsul cu id-ul dat nu exista");
            }

            _produseRepository.Delete(produseToDelete);
            await _produseRepository.SaveAsync();
        }

        public async Task UpdateProdus(UpdateProdusDto updateProdus)
        {
            var oldProdus = await _produseRepository.FindByIdAsync(updateProdus.ProdusId);
            if (oldProdus == null)
            {
                throw new Exception("Produsul cu id-ul dat nu exista");
            }

            oldProdus.Nume = updateProdus.Nume;
            oldProdus.DataExpirare = updateProdus.DataExpirare;
            oldProdus.Cantitate = updateProdus.Cantitate;
            oldProdus.Fabrica = updateProdus.Fabrica;
            oldProdus.DateModified = DateTime.Now;

            _produseRepository.Update(oldProdus);
            await _produseRepository.SaveAsync();
        }

        public async Task<List<NrProduseProducatoriDTO>> GetCantitateProducatori()
        {
            var produse = await _produseRepository.GetProduseCuProducatori();

            var groupedProduse = produse.GroupBy(x => x.Producator).Select(group => new NrProduseProducatoriDTO
            {
                NumeProducator = group.Key.NumeProducator,
                NrProduse = group.Count()
            }).ToList();

            return groupedProduse;
        }
    }
}
