using Brasileirao.web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Jogos>  Jogos{get; set;}

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {


             
        }


    }
}
