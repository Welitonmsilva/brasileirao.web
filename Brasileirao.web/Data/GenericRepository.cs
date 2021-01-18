

namespace Brasileirao.web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using Brasileirao.web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    


    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity

    {





        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;

        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsinc();
        }



        public IQueryable<T> Getall()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetbyIdAsync(int id)
        {
            return await _context.Set<T>()
           .AsNoTracking()
              .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsinc();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsinc();
        }
        private async Task<bool> SaveAllAsinc()
        {
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> ExistsAsync(int Id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == Id);
        }
    }
}
