

namespace Brasileirao.web.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    public  interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Getall();

        Task<T> GetbyIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistsAsync(int Id);




    }
}
