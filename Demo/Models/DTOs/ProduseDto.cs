namespace Demo.Models.DTOs
{
    public class ProduseDto
    {
        public string Denumire { get; set; }= string.Empty;

        public int DataExpirarii { get; set; }
        public int Cantitate { get; set; }
        public string Fabrica { get; set; } = string.Empty;

        public ICollection<CategorieDto>? Categorie { get; set; }
    }
}