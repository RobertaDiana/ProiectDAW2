using Demo.Models.Base;
using Demo.Models.Enums;
using System.Data;
using System.Text.Json.Serialization;

namespace Demo.Models
{
    public class Producator: BaseEntity
    {
        public string NumeProducator { get; set; }

        public DateTime DataVenire { get; set; }

        public string Email { get; set; }

        public ICollection<Produse> Produse { get; set; }

        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
