using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs.Producator;
using Demo.Models.Enums;
using Demo.Repositories.ProducatorRepository;
using ProiectDAW2.Helpers.Jwt;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectDAW2.Servicies
{
    public class ProducatorService: IProducatorService
    {
        public IProducatorRepository _producatorRepository;
        public IJwtUtils _jwtUtilis;
        public IMapper _mapper;

        public ProducatorService(IProducatorRepository producatorRepository, IJwtUtils jwtUtilis, IMapper mapper)
        {
            _producatorRepository = producatorRepository;
            _jwtUtilis = jwtUtilis;
            _mapper = mapper;
        }

        public ProducatorAuthResponseDto Authentificate(ProducatorAuthRequestDto model)
        {
            var producator = _producatorRepository.FindByEmail(model.Email);
            if (producator == null || !BCryptNet.Verify(model.Password, producator.PasswordHash))
            {
                return null; // or throw exception
            }

            // jwt generation
            var jwtToken = _jwtUtilis.GenerateJwtToken(producator);
            return new ProducatorAuthResponseDto(producator, jwtToken);
        }

        public async Task Create(ProducatorAuthRequestDto producator)
        {
            var newDBProducator = _mapper.Map<Producator>(producator);
            newDBProducator.PasswordHash = BCryptNet.HashPassword(producator.Password);
            newDBProducator.Role = Role.User;

            await _producatorRepository.CreateAsync(newDBProducator);
            await _producatorRepository.SaveAsync();
        }

        public async Task<List<Producator>> GetAllProducatori()
        {
            return await _producatorRepository.GetAllAsync();
        }

        public async Task<Producator> GetById(Guid id)
        {
            return await _producatorRepository.FindByIdAsync(id);
        }
    }
}
