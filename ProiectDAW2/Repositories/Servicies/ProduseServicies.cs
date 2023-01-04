using ProiectDAW2.Models;
using ProiectDAW2.Models.DTOs;

using ProiectDAW2.Repositories.ProdusRepository;

namespace ProiectDAW2.Servicies
{
    public class ProduseServicies : IProduseServicies

    {
        public IProduseRepository _produseRepository;


        public ProduseServicies(IProduseRepository produseRepository)
        {
            _produseRepository = produseRepository;
        }

        public Task<List<ProduseDto>> GetAllProduse()
        {
            return _produseRepository.GetAll();
        }
    }
}
