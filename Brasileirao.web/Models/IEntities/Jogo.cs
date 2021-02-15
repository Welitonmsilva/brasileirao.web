using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Jogo : IEntity
    {

        [Key]
        public int Id { get; set; }

        public int Jornadas { get; set; }

        public string Clube { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public User User { get; set; }

    }
}
