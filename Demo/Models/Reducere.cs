using Demo.Models.Base;

namespace Demo.Models
{
    public class Reducere: BaseEntity
    {
        public double Valoare { get; set; }

        public Produse Produse { get; set; }
    }
}
