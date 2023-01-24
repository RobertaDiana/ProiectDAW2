using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs.Producator
{
    public class ProducatorAuthResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NumeProducator { get; set; }

        public string Token { get; set; }

        public ProducatorAuthResponseDto(Models.Producator producator, string token)
        {
            Id = producator.Id;
            NumeProducator = producator.NumeProducator;
            Email = producator.Email;
            Token = token;
        }
    }
}
