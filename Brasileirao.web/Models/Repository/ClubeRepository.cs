using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public class ClubeRepository : GenericRepository<Clube>, IClubeRepository
    {
        public ClubeRepository(DataContext context) : base(context)
        {
        }

    }
}
