using GenericRepositoryUOWorkWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepositoryUOWorkWebAPI.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly APIDBContext _context;
        protected DbSet<T> _dbSet;
        protected ILogger _logger;

        public GenericRepository(APIDBContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;

        }

        public virtual async Task<bool> Ekle(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<T> GetirById(Guid id)
        {

            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetirFiltreli(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }


        public virtual async Task<IEnumerable<T>> GetirHepsi()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> Güncelle(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public virtual async Task<bool> Sil(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            return true;
        }

    }
}
