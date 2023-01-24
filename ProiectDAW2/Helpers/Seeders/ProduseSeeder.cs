using Demo.Data;
using Demo.Models;

namespace ProiectDAW2.Helpers.Seeders
{
    public class ProduseSeeder
    {
        public readonly Proiect2Context _proiect2Context;

        public ProduseSeeder(Proiect2Context proiect2Context)
        {
            _proiect2Context = proiect2Context;
        }

        public void SeedIntialProduse()
        {
            if (!_proiect2Context.Produse.Any())
            {
                var produs1 = new Produse
                {
                    Nume = "Produs1",
                    DataExpirare = 21,
                    Cantitate = 30,
                    Fabrica = "Milka"
                };

                var produs2 = new Produse
                {
                    Nume = "Produs2",
                    DataExpirare = 24,
                    Cantitate = 35,
                    Fabrica = "Aptamil"
                };

                _proiect2Context.Add(produs1);
                _proiect2Context.Add(produs2);

                _proiect2Context.SaveChanges();
            }
        }
    }
}
