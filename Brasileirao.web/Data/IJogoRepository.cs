using Brasileirao.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    interface IJogoRepository :IGenericRepository<Jogos>
    {
        IEnumerable<SelectListItem> GetComboProducts();
    }
}
