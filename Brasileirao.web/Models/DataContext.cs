﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.web.Models
{
    public class DataContext : IdentityDbContext<User>
    {


        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<User> Users { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
        }





    }
}