using ProiectDAW2.Models.Base;

namespace ProiectDAW2.Models
{
    public class Categorie: BaseEntity
    {
        public string Denumire { get; set;}
        public int Numar { get; set; }

        public ICollection<Ingrediente> Ingrediente { get; set; }
    }
}
