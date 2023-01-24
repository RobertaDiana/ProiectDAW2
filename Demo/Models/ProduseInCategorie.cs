using Demo.Models.Base;
using System.Reflection;

namespace Demo.Models
{
    public class ProduseInCategorie: BaseEntity
    {
        public Guid ProduseId { get; set; }
        public Produse Produse { get; set; }


        public Guid CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
