using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs.Producator
{
    public class UpdateProducatorDto
    {
        public Guid Id { get; set; }

        public string NumeProducator { get; set; }

        public DateTime DataVenire { get; set; }

        public string Email { get; set; }
    }
}
