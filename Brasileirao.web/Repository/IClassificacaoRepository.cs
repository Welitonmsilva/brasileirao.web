﻿using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Repository
{
    public interface IClassificacaoRepository
    {
        IEnumerable<Classificacao> classificacaos { get; }
    }
}
