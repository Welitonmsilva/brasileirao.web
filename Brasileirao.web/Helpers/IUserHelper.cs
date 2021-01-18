using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.web.Data.Entities;

namespace Brasileirao.web.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);


        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
