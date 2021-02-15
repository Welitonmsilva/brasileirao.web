using Brasileirao.web.Helpers;
using Brasileirao.web.Models;
using Brasileirao.web.Models.IEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;
        //contrutor
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        //metodo asyncrono
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

          

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

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToReleAseync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToReleAseync(user, "Admin");
            }


        }

    }
}






