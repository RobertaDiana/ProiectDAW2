using ProiectDAW2.Data;
using ProiectDAW2.Models;
using ProiectDAW2.Models.DTOs;
using ProiectDAW2.Repositories.GenericRepository;

namespace ProiectDAW2.Repositories.ProdusRepository
{
    public class ProduseRepository : GenericRepository<Produse>, IProduseRepository
    {
        public ProduseRepository(Proiect2Context context) : base(context)
        {

        }
    }
}
