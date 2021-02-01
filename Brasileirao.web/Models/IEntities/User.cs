using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class User : IdentityUser
    {

         public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
