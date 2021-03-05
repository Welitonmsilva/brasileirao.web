

using Brasileirao.web;
using Brasileirao.web.Context;
using Brasileirao.web.Controllers;
using Brasileirao.web.Models.IEntities;
using Brasileirao.web.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Brasileirao.Web.Data.Repositories
{
    public class JogoRepository :IJogoRepository
    {
        private readonly Db_Context _context;

        public JogoRepository(Db_Context context)
        {
            _context = context;
        }

        public IEnumerable<Jogo> Jogos => _context.jogos.Include( c => c.Classificacao);

        public IEnumerable<Jogo> jogosClassificacao => _context.jogos.Where( c => (bool)c.Classificacao);

        public Jogo GetJogoById(int jogoId)
        {
            return _context.jogos.FirstOrDefault(j => j.JogoId == jogoId);
        }
    }
}
