using Demo.Models;
using Demo.Models.DTOs.Producator;
using Demo.Models.Enums;

namespace ProiectDAW2.Servicies
{
    public interface IProducatorService
    {
        ProducatorAuthResponseDto Authentificate(ProducatorAuthRequestDto model);
        Task<ProducatorDto> GetProducator(Guid producatorId);
        Task<Producator> GetById(Guid id);
        Task Create(ProducatorAuthRequestDto newProducator, Role role);
        Task UpdateProducator(UpdateProducatorDto updateProducator);
        Task DeleteProducator(Guid producatorId);
    }
}
