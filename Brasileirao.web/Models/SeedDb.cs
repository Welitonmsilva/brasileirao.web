using Microsoft.AspNetCore.Identity;
using Brasileirao.web.Helpers;
//using Brasileirao.web.Models.entities;
//using Brasileirao.web.Models.Ientities;


using System;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.web.Models;
using Brasileirao.web.Models.IEntities;

namespace Brasileirao.web.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;        
        private  Random _random;

        public SeedDb(DataContext context, UserManager<User> _userManager)
        {
            _context = context;
            _userManager = _userManager;
            _random = new Random();
            
        }



        //public async Task SeedAsync()
        //{
        //    await _context.Database.EnsureCreatedAsync();
        //    //await _userHelper.CheckRoleAsync("Admin");
        //    //await _userHelper.CheckRoleAsync("Customer");


        //    var user = await _userManager.FindByEmailAsync("weliton.mesquita.silva@formandos.cinel.pt");
        //    if (user == null)
        //    {
        //        user = new User
        //        {
        //            FirstName = "weliton",
        //            LastName = "Silva",
        //            Email = "weliton.mesquita.silva@formandos.cinel.pt",
        //            UserName = "weliton.mesquita.silva@formandos.cinel.pt",
        //        };

        //        var result = await this._userManager.CreateAsync(user, "123456");

        //        if (result != IdentityResult.Success)
        //        {
        //            throw new InvalidOperationException("Could not create the user in seeder");
        //        }
        //        //await _userHelper.AddUserToRoleAsync(user, "Admin");

        //    }
        //    //var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
        //    //if (!isInRole)
        //    //{
        //    //    await _userHelper.AddUserToRoleAsync(user, "Admin");
        //    //}

        //    if (!_context.Jogos.Any())
        //    {
        //        this.AddJogo( " Flamendo", 1, 2, user);
        //        this.AddJogo(" Palmeiras", 1, 3, user);
        //        this.AddJogo(" São Paulo", 1, 2, user);
        //        this.AddJogo(" Santos", 1, 2, user);
        //        this.AddJogo(" Bota Fogo", 1, 2, user);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //private void AddJogo(string name, int num,int pos, User user)
        //{
        //    _context.Jogos.Add(entity: new Jogo
        //    {
        //        Clube = name,
        //        Jornadas = _random.Next(100),
        //        Pontos = num,
        //        //ultimoJogo = dateTime,
        //        Posicao = pos,
        //        User = user
        //    });

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
