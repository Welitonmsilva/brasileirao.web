using Brasileirao.web.Context;
using Brasileirao.web.Models.IEntities;
using System.Collections.Generic;

namespace Brasileirao.web.Repository
{
    public class ClassificacaoRepository : IClassificacaoRepository

    {
        private readonly Db_Context _Context;
        public ClassificacaoRepository(Db_Context context)
        {
            _Context = context;
        }

        public IEnumerable<Classificacao> classificacaos => _Context.classificacaos;

    }
}
