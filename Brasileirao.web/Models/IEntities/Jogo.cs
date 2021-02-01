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

        [DisplayFormat(DataFormatString = "{0:2}", ApplyFormatInEditMode = false)]
        public decimal Jornadas { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        public string Clube { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        //[Display(Name = "Ultimo Jogo")]
        //public DateTime ultimoJogo { get; set; }

        //internal static string Getjogos()
        //{
        //    throw new NotImplementedException();
        //}
        public User User { get; set; }

        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        public string Name { get; set; }

        public string email { get; set; }

    }
}
