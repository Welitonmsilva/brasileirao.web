

namespace Brasileirao.web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Brasileirao.web.Models;
    using System.Threading.Tasks;
    using Brasileirao.web.Models.IEntities;

    public class UserHelper : IUserHelper
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(UserManager<User> userManager, 
            SignInManager<User> signInManager,
                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }  
        public  async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username, 
                model.Password,
                model.RememberMe,
                false);//esta em false poque se colocar x tentativas ele bloqueia a conta
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }        

        //public async Task AddUserToRoleAsync(User user, string roleName)
        //{
        //    await _userManager.AddToRoleAsync(user, roleName);
        //}
        public async Task<IdentityResult> ChangePassewordAsync(User user, string oldPassword, string newPasseWord)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPasseWord);
        }
        public async Task<IdentityResult> UpdateUserAseync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }
        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await this._userManager.IsInRoleAsync(user, "Admin");
        }

        public  async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public  async Task AddUserToReleAseync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
