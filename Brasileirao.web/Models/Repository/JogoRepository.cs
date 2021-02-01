using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public class JogoRepository : GenericRepository<Jogo>, IJogoRepository
    {
        public JogoRepository(DataContext context) : base(context)
        {

        }

        public void AddJogos(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Jogo Getjogos(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogo> Getjogos()
        {
            throw new NotImplementedException();
        }

        public bool JogostExists(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveJogos(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void UpdateJogos(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        //public void AddJogo(Jogo jogo)
        //{
        //    throw new NotImplementedException();
        //}

        //public Jogo GetJogo(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Jogo> GetJogos()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool ProductExists(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveJogo(Jogo Jogo
        //    )
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateJogo(Jogo jogo)
        //{
        //    throw new NotImplementedException();
        //}


    }

}
