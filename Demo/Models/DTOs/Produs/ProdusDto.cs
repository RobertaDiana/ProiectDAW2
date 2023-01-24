namespace Demo.Models.DTOs.Produs
{
    public class ProdusDto
    {
        public string Nume { get; set; } = string.Empty;
        public DateTime DataExpirare { get; set; }
        public int Cantitate { get; set; }
        public string Fabrica { get; set; } = string.Empty;

        public Guid ProducatorId { get; set; }
    }
}