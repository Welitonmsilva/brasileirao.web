

namespace Brasileirao.web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Brasileirao.web.Data.Entities;
    using Brasileirao.web.Helpers;
    using Microsoft.AspNetCore.Identity;
    
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly UserManager<User> userManager;
        private readonly IUserHelper _userHelper;       
        private readonly Random _random;

        public SeedDb(DataContext context, UserManager<User> userManager,IUserHelper userHelper)
        {
            _context = context;
            this.userManager = userManager;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await _userHelper.CheckRoleAsync("Admin");
            //await _userHelper.CheckRoleAsync("Customer");

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
                this.AddJogo(" 1X");
                this.AddJogo("2");
                this.AddJogo("3");
                this.AddJogo("4");
                this.AddJogo("5");
                await _context.SaveChangesAsync();
            }
        }

        private void AddJogo(string v)
        {
            throw new NotImplementedException();
        }

        private void AddJogo(string name, int num, DateTime dateTime)
        {
            _context.Jogos.Add(new Jogo
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
