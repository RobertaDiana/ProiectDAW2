using ProiectDAW2.Models.Base;
using System.Reflection;

namespace ProiectDAW2.Models
{
    public class Ingrediente: BaseEntity
    {
        public Guid ProduseId{ get; set; }
        public Produse Produse { get; set; }


        public Guid CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
