using Demo.Data;
using Demo.Models;
using Demo.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.CategorieRepository
{
    public class CategorieRepository : GenericRepository<Categorie>, ICategorieRepository
    {
        public CategorieRepository(Proiect2Context context) : base(context)
        { }
    }
}
