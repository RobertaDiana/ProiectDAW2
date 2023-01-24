using Demo.Models;
using Demo.Models.DTOs.Producator;

namespace ProiectDAW2.Servicies
{
    public interface IProducatorService
    {
        ProducatorAuthResponseDto Authentificate(ProducatorAuthRequestDto model);
        Task<List<Producator>> GetAllProducatori();
        Task<Producator> GetById(Guid id);
        Task Create(ProducatorAuthRequestDto newProducator);
    }
}
