

namespace Brasileirao.web.Data
{
    
    using Brasileirao.web.Helpers;
    using Brasileirao.web.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;



    public class SeedDb
    {

        private readonly DataContext _context;
        //private readonly IUserHelper _userHelper;
        private  Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;

            _userHelper = userHelper;
            _random = new Random();
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await _userHelper.CheckRoleAsync("Admin");
            //await _userHelper.CheckRoleAsync("Customer");


            var user = await _userHelper.GetUserByEmailAsync("weliton.mesquita.silva@formandos.cinel.pt");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "weliton",
                    LastName = "Silva",
                    Email = "weliton.mesquita.silva@formandos.cinel.pt",
                    UserName = "weliton.mesquita.silva@formandos.cinel.pt",
                };

                var result = await this._userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

            }

            if (!_context.Jogos.Any())
            {
                this.AddJogo("1", user);
                this.AddJogo("2", user);
                this.AddJogo("3", user);
                this.AddJogo("4", user);
                this.AddJogo("5", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddJogo(string v, User user)
        {
            throw new NotImplementedException();
        }

        private void AddJogo(string name, User user, int num/*, DateTime dateTime*/)
        {
            _context.Jogos.Add(new Jogo
            {
                Jornadas = name,
                Clube = name,
                Pontos = num,
                //ultimoJogo = dateTime,
                Posicao = num,
                User = user
            });

            //private void AddJogo(string )
            //{




            //    });
        }
    }
}
