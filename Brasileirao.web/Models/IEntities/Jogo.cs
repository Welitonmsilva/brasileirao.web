using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models
{
    public class Jogo : IEntity
    {
        public int Id { get; set; }

        
        public int Jornadas { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        public string Clube { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


       public User User { get; set; }



    }
}
