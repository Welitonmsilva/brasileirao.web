using Brasileirao.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    public class JogoRepository : GenericRepository<Jogos>, IJogoRepository
    {

        public JogoRepository(DataContext context) : base(context)
        {
        }
    }
}
