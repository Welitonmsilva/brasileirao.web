using Microsoft.AspNetCore.Identity;
using Brasileirao.web.Helpers;
//using Brasileirao.web.Models.entities;
//using Brasileirao.web.Models.Ientities;


using System;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.web.Models;

namespace Brasileirao.web.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private  Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper, Random random)
        {
            _context = context;

            _userHelper = userHelper;
            _random = new Random();
            //_random = random;
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
                //await _userHelper.AddUserToRoleAsync(user, "Admin");

            }
            //var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            //if (!isInRole)
            //{
            //    await _userHelper.AddUserToRoleAsync(user, "Admin");
            //}

            if (!_context.Jogos.Any())
            {
                this.AddJogo(" iPhone X 1", user);
                this.AddJogo(" iPhone X 2", user);
                this.AddJogo(" iPhone X 3", user);
                this.AddJogo(" iPhone X 4", user);
                this.AddJogo(" iPhone X 5", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddJogo(string name, User user)
        {
            _context.Jogos.Add(entity: new Jogo
            {
                Jornadas = name.Normalize(),
                Clube = name,
                //Pontos = num,
                //ultimoJogo = dateTime,
                //Posicao = num,
                User = user
            });

        //private void AddJogo(string name, User user,int num)
        //{
        //    _context.Jogos.Add(new Jogo
        //    {
        //        Jornadas = name,
        //        Clube = name,
        //        Pontos = num,
        //        //ultimoJogo = dateTime,
        //        Posicao = num,
        //        User = user
        //    });
        //}

        //private void AddJogo(string name, User user, int num/*, DateTime dateTime*/)
        //{
        //    _context.Jogos.Add(new Jogo
        //    {
        //        Jornadas = name,
        //        Clube = name,
        //        Pontos = num,
        //        //ultimoJogo = dateTime,
        //        Posicao = num,
        //        User = user
        //    });
        }


    }
    
}
