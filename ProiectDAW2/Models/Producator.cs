using ProiectDAW2.Models.Base;

namespace ProiectDAW2.Models
{
    public class Producator: BaseEntity
    {
        public string NumeProducator { get; set; }

        public int DataVenirii { get; set; }

        public string Email { get; set; }

        public ICollection<Produse> Produse { get; set; }   


    }
}
