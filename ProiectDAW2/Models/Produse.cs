

using ProiectDAW2.Models.Base;

namespace ProiectDAW2.Models
{
    public class Produse : BaseEntity
    {
        public string Nume { get; set; }

        public int DataExpirare { get; set; }

        public int Cantitate { get; set; }

        public string Fabrica { get; set; }

        public ICollection<Ingrediente> Ingrediente { get; set; }

        public Producator Producator { get; set; }

        public Reducere Reducere { get; set; }

    }
}
