using Brasileirao.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    public class ClubeRepository : GenericRepository<Clube>, IclubeRepsositrory
    {
        public ClubeRepository(DataContext context) : base(context)
        {

        }

    }
}
