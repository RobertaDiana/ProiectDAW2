using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.DTOs.Categorie
{
    public class UpdateCategorieDto
    {
        public Guid Id { get; set; }
        public string Denumire { get; set; }
        public int Numar { get; set; }
    }
}
