using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Brasileirao.web.Models.Repository
{
    public class CampoRepository : GenericRepository<Campo>, ICampoRepository
    {
        public CampoRepository(DataContext context) : base(context)
        {
        }


        public void AddCampo(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Jogo GetCampo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogo> GetCampo()
        {
            throw new NotImplementedException();
        }

        public bool CampotExists(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCampo(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void UpdateCampo(Jogo jogo)
        {
            throw new NotImplementedException();
        }
    }
}
