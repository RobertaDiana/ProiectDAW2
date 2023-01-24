using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs.Producator
{
    public class ProducatorAuthRequestDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string? NumeProducator { get; set; }
       
    }
}
