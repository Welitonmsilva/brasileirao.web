using Brasileirao.web.Models.IEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Brasileirao.web.Models
{
    public class DataContext : IdentityDbContext<User>
    {


        public DbSet<Jogo> Jogos { get; set; }        

        public DbSet<Clube> Clubes { get; set; }
        public DbSet<User> User { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            //Habilitar a cascade Rule
            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);


            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            }

            base.OnModelCreating(modelBuilder);

        }




    }
}
