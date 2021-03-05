using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Classificacao
    {
        public int ClassificacaoId { get; set; }
        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string ClassificacaoNome { get; set; }

        //[Required]
        //[StringLength(200)]
        //public string Descricao { get; set; }

        public List<Jogo> Jogos { get; set; }

        



    }
}
