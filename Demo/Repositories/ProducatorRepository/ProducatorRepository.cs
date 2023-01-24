using Demo.Data;
using Demo.Models;
using Demo.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.ProducatorRepository
{
    public class ProducatorRepository : GenericRepository<Producator>, IProducatorRepository
    {
        public ProducatorRepository(Proiect2Context context) : base(context)
        { }

        public Producator FindByEmail (string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}
