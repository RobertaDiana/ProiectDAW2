using Demo.Models;

namespace ProiectDAW2.Helpers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Producator producator);
        public Guid ValidateJwtToken(string token);
    }
}
