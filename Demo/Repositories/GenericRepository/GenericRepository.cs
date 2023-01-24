using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Models.Base;

namespace Demo.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Proiect2Context _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(Proiect2Context context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();

        }

        // create
        

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // delete

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // find
        public TEntity FindById(object id)
        {
            return _table.Find(id);

        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);

        }

        // save

       

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
