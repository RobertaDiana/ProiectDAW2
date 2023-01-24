using Demo.Models.Base;

namespace Demo.Models
{
    public class Categorie: BaseEntity
    {
        public string Denumire { get; set;}
        public int Numar { get; set; }

        public ICollection<ProduseInCategorie> ProduseInCategorie { get; set; }

        public object FindIndex(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
