using Demo.Data;
using Demo.Models;
using Demo.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.ProduseInCategorieRepository
{
    public class ProduseInCategorieRepository : GenericRepository<ProduseInCategorie>, IProduseInCategorieRepository
    {
        public ProduseInCategorieRepository(Proiect2Context context) : base(context) 
        { }
    }
}
