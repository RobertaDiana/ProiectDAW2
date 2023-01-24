using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs
{
    public class CategoriecuProduseDto:CategorieDto
    {
        public ICollection<ProduseDto>? Produse { get; set; }
    }
}
