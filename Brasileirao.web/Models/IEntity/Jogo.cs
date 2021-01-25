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

        public string Jornadas { get; set; }

        public string Clube { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Ultimo Jogo")]
        //public DateTime ultimoJogo { get; set; }

        //internal static string Getjogos()
        //{
        //    throw new NotImplementedException();
        //}
        public User User { get; set; }
        public string Name { get; set; }
        //public string Name { get ; set ; }
    }
}
