using ProiectDAW2.Models.DTOs;

namespace ProiectDAW2.Servicies
{
    public interface IProduseServicies
    {
        Task<List<ProduseDto>> GetAllProduse();
    }
}
