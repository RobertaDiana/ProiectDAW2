using ProiectDAW2.Models.Base;

namespace ProiectDAW2.Models
{
    public class Reducere: BaseEntity
    {
        public double Valoare { get; set; }

        public Produse Produse { get; set; }
    }
}
