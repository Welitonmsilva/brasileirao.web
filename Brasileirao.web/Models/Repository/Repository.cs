using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public class Repository : IRepository
    {

        private readonly DataContext _context;


        public Repository(DataContext context)
        {
            _context = context;
        }


        //Método que vai buscar os jogo todos
        public IEnumerable<Jogo> GetJogo()
        {
            return _context.Jogos.OrderBy(p => p.Clube);
        }





        //Método que adiciona um jogo á tabela
        public void AddJogo(Jogo Jogo
            )
        {
            _context.Jogos.Add(Jogo);
        }


        //Método que atualiza (update) um jogo
        public void UpdateJogo(Jogo Jogo)
        {
            _context.Update(Jogo);
        }


        //Método que remove um Jogo
        public void RemoveJogo(Jogo Jogo)
        {
            _context.Jogos.Remove(Jogo);
        }


        //Método que atualiza a BD
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        //Método que verifica se o Jogo existe
        public bool JogotExists(int Id)
        {
            return _context.Jogos.Any(p => p.Id == Id);
        }

        public void AddJogo(Clube clube)
        {
            throw new NotImplementedException();
        }

        public Jogo GetJogo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogo> GetJogos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogo> GetClube()
        {
            throw new NotImplementedException();
        }

        public bool clubetExists(int Id)
        {
            throw new NotImplementedException();
        }

        public void Removeclube(Clube clube)
        {
            throw new NotImplementedException();
        }

        public void Removejogo(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Updateclube(Clube clube)
        {
            throw new NotImplementedException();
        }
    }
}

    

