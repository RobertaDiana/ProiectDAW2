using Demo.Models.DTOs;

namespace ProiectDAW2.Servicies
{
    public interface IProduseServicies
    {
        Task<List<ProduseDto>> GetAllProduse();
        public Task AddProduse(ProduseDto newProduse);
        public Task DeleteProduse(Guid produseId);
    }
}
