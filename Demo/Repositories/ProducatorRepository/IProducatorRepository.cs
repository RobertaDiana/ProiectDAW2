using Demo.Models;
using Demo.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repositories.ProducatorRepository
{
    public interface IProducatorRepository : IGenericRepository<Producator>
    {
        Producator FindByEmail(string email);
    }
}
