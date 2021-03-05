using Brasileirao.web.Models.IEntities;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.web.Context
{
    public class Db_Context : DbContext
    {

        public Db_Context(DbContextOptions<Db_Context> options) : base(options) { }

        public DbSet<Jogo> jogos { get; set; }

        public DbSet<Classificacao> classificacaos { get; set; }
    }
}
