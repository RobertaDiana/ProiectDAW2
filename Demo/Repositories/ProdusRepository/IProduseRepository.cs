using Demo.Models;
using Demo.Models.DTOs;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories.ProdusRepository
{
    public interface IProduseRepository : IGenericRepository<Produse>
    {
        public Task<List<Produse>> FindRange(List<Guid> produseIds);

        public Task<List<Produse>> GetAllProduseOrdonate();

        public Task<List<Produse>> GetProduseInTermenCuProducatori();

        public Task<List<Produse>> GetProduseCuProducatori();
    }
}
