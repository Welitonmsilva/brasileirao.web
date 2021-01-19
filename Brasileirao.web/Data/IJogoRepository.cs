using Brasileirao.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
   public interface IJogoRepository :IGenericRepository<Jogo>
    {
        IEnumerable<SelectListItem> Getjogos();
        Task SaveAllAsync();
    }
}
