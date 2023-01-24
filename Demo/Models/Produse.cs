

using Demo.Models.Base;

namespace Demo.Models
{
    public class Produse : BaseEntity
    {
        public string Nume { get; set; }

        public DateTime DataExpirare { get; set; }

        public int Cantitate { get; set; }

        public string Fabrica { get; set; }

        public ICollection<ProduseInCategorie> ProduseInCategorie { get; set; }

        public Producator Producator { get; set; }

        public Guid ProducatorId { get; set; }

        public Reducere? Reducere { get; set; }

        public Guid? ReducereId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
