

namespace Brasileirao.web.Data
{
    using Brasileirao.web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Clube> Clubes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }       



    }
}
