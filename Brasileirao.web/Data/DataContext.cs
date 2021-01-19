

namespace Brasileirao.web.Data
{
    using Brasileirao.web.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Clube> Clubes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }       



    }
}
