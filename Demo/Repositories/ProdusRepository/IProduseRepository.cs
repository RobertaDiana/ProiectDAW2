using Demo.Models;
using Demo.Models.DTOs;
using Demo.Repositories.GenericRepository;

namespace Demo.Repositories.ProdusRepository
{
    public interface IProduseRepository : IGenericRepository<Produse>
    {
        public Task<List<Produse>> FindRange(List<Guid> produseIds);
        public void GroupBy();
        public void OrderByDataExpirarii();
    }
}
