using Demo.Data;
using Demo.Models;
using Demo.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.DatabaseRepository
{
    public class DatabaseRepository: GenericRepository<Produse>, IDatabaseRepository
    {
        public DatabaseRepository(Proiect2Context proiect2Context) : base(proiect2Context)
        {

        }

        public Produse GetByNume(string nume)
        {
            return _table.FirstOrDefault(x => x.Nume.ToLower().Trim().Equals(nume.ToLower().Trim()));
        }

        public async Task<Produse> GetByNumeAsync(string nume)
        {
            return await _table.FirstOrDefaultAsync(x => x.Nume.ToLower().Trim().Equals(nume.ToLower().Trim()));
        }

        public Produse GetByNumeIncludingCategorie(string nume)
        {
            return _table.Include(x => x.ProduseInCategorie).FirstOrDefault(x => x.Nume.ToLower().Trim().Equals(nume.ToLower().Trim()));
        }

        public async Task<List<Produse>> GetAllWithInclude()
        {
            return await _table.Include(x => x.ProduseInCategorie).ToListAsync();
        }

        public async Task<List<Produse>> GetAllWithJoin()
        {
            var result = _table.Join(_context.Categorie, produse => produse.Id, categorie => categorie.Id,
                (produse, categorie) => new { produse, categorie }).Select(x => x.produse);
            
            return await result.ToListAsync();
        }

        public Produse WhereWithLinqQuerySyntax(int cantitate)
        {
            var result = from p1 in _table
                         where p1.Cantitate == cantitate
                         select p1;

            return result.FirstOrDefault();
        }

    }
}
