using Demo.Models;
using Demo.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.DatabaseRepository
{
    public interface IDatabaseRepository: IGenericRepository<Produse>
    {
        Produse GetByNume(string nume);
        Produse GetByNumeIncludingCategorie(string nume);

        Task<List<Produse>> GetAllWithInclude();
        Task<List<Produse>> GetAllWithJoin();
    }
}
