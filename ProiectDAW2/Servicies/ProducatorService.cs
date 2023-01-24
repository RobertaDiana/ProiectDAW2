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

        public async Task<ProducatorDto> GetProducator(Guid producatorId)
        {
            var dbProducator = await _producatorRepository.FindByIdAsync(producatorId);

            var producator = _mapper.Map<ProducatorDto>(dbProducator);
            return producator;
        }

        public async Task Create(ProducatorAuthRequestDto producator, Role role)
        {
            var newDBProducator = _mapper.Map<Producator>(producator);
            newDBProducator.PasswordHash = BCryptNet.HashPassword(producator.Password);
            newDBProducator.Role = role;

            await _producatorRepository.CreateAsync(newDBProducator);
            await _producatorRepository.SaveAsync();
        }

        public async Task<Producator> GetById(Guid id)
        {
            return await _producatorRepository.FindByIdAsync(id);
        }

        public async Task UpdateProducator(UpdateProducatorDto updateProducator)
        {
            var oldProducator = await _producatorRepository.FindByIdAsync(updateProducator.Id);
            if (oldProducator == null)
            {
                throw new Exception("Producatorul cu id-ul dat nu exista");
            }

            oldProducator.NumeProducator = updateProducator.NumeProducator;
            oldProducator.DataVenire = updateProducator.DataVenire;
            oldProducator.Email = updateProducator.Email;
            oldProducator.DateModified = DateTime.Now;

            _producatorRepository.Update(oldProducator);
            await _producatorRepository.SaveAsync();
        }

        public async Task DeleteProducator(Guid producatorId)
        {
            var producatorToDelete = await _producatorRepository.FindByIdAsync(producatorId);
            if (producatorToDelete == null)
            {
                throw new Exception("Producatorul cu id-ul dat nu exista");
            }

            _producatorRepository.Delete(producatorToDelete);
            await _producatorRepository.SaveAsync();
        }
    }
}
