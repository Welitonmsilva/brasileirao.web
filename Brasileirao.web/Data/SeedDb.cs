

namespace Brasileirao.web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Brasileirao.web.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

            var user = await _userHelper.GetUserByEmailAsync("rafael.santos@cinel.pt");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Rafael",
                    LastName = "Santos",
                    Email = "rafael.santos@cinel.pt",
                    UserName = "rafael.santos@cinel.pt",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

            }

            if (!_context.Jogos.Any())
            {
                //this.AddJogo(" 1X", nome)
                //this.AddJogo("2", name)
                //this.AddJogo("3", user);
                //this.AddJogo("4", user);
                //this.AddJogo("5", user);
                await _context.SaveChangesAsync();
            }
        }


        private void AddJogo(string name, int num, DateTime dateTime)
        {
            _context.Jogos.Add(new Jogos
            {
                Jornadas = name,
                Clube = name,
                Pontos = num,
                ultimoJogo = dateTime,
                Posicao = num,



            });
        }
    }
}
