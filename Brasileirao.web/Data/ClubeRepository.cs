using Brasileirao.web.Data.Entities;

namespace Brasileirao.web.Data
{
    public class ClubeRepository : GenericRepository<Clube>, IclubeRepsositrory
    {
        public ClubeRepository(DataContext context) : base(context)
        {

        }

    }
}
