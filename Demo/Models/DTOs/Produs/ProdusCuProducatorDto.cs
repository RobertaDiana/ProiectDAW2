using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs.Produs
{
    public class ProdusCuProducatorDto
    {
        public string Nume { get; set; } = string.Empty;
        public DateTime DataExpirare { get; set; }
        public int Cantitate { get; set; }
        public string Fabrica { get; set; } = string.Empty;

        public string NumeProducator { get; set; }
    }
}
