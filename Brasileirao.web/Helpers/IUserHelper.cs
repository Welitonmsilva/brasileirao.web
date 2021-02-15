using Brasileirao.web.Models;
using Brasileirao.web.Models.IEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);


        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAseync(User user);

        Task<IdentityResult> ChangePassewordAsync(User user, string oldPassword, string newPasseWord);
        Task CheckRoleAsync(string roliName);

        Task AddUserToReleAseync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);


    }
}
