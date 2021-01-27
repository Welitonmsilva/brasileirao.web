using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public interface IRepository
    {

        void AddJogo(Jogo jogo);
        void AddJogo(Clube clube);


        Jogo GetJogo(int id);


        IEnumerable<Jogo> GetJogos();
        IEnumerable<Jogo> GetClube();


        bool JogotExists(int Id);
        bool clubetExists(int Id);


        void Removeclube(Jogo jogo);


        Task<bool> SaveAllAsync();


        void UpdateJogo(Jogo jogo);
    }
}
