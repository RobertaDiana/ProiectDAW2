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
        
        public void OrderByDataExpirarii()
        {
            var produseOrderAsc1 = _table.OrderBy(x => x.DataExpirare);
            var produseOrderDesc1 = _table.OrderBy(x => x.DataExpirare);
        }
        public void GroupBy()
        {
            var groupedProduse1 = from p in _table
                                   group p by p.Cantitate;

            foreach (var produseGroupByCantitate in groupedProduse1)
            {
                Console.WriteLine("Produsele grupate in cantitate: " + produseGroupByCantitate.Key);
                foreach (Produse p in produseGroupByCantitate)
                {
                    Console.WriteLine("Denumirea Produsului: " + p.Nume);
                }
            }

            var groupedProduse2 = _table.GroupBy(x => x.Cantitate);
        }
    }
}
