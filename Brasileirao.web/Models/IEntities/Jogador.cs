using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Jogador : IEntity
    {



        
        [Key]
        public int Id { get; set; }
        public int num_B_I { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public int idade { get; set; }
        public User user { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

      
        public int Clube { get; set; }

     
        public int Posicao { get; set; }

      
        public int Cidade { get; set; }
        
    }
}
