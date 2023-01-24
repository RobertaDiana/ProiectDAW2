using Demo.Data;
using Demo.Models;
using Demo.Models.DTOs;
using Demo.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.ProdusRepository
{
    public class ProduseRepository : GenericRepository<Produse>, IProduseRepository
    {
        public ProduseRepository(Proiect2Context context) : base(context)
        {

        }
        public async Task<List<Produse>> FindRange(List<Guid> produseIds)
        {
            return await _table.Where(x => produseIds.Contains(x.Id)).ToListAsync();
        }
        
        //produsele ordonate dupa data de expirare
        public async Task<List<Produse>> GetAllProduseOrdonate()
        {
            return await _table.OrderBy(x => x.DataExpirare).ToListAsync();
        }

        //produse in termen si cu numele producatorului (where+include)
        public async Task<List<Produse>> GetProduseInTermenCuProducatori()
        {
            return await _table.Where(x => x.DataExpirare > DateTime.Now).Include(x => x.Producator).ToListAsync();
        }


        //producatorii si cate tipuri de produse au fiecare 
        public async Task<List<Produse>> GetProduseCuProducatori()
        {
            return await _table.Include(x => x.Producator).ToListAsync();
        }
    }
}
