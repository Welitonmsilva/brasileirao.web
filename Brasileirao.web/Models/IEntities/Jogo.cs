using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Jogo 
    {
        internal readonly object Classificacao;

        [Key]
        public int JogoId { get; set; }

        public string Name { get; set; }

        public int Jornadas { get; set; }

        public IEnumerable<Clube>  Clube{ get; set; }

        public int Pts { get; set; }//Aqui declara-se os pontos da equipa

        public int V { get; set; }//Aqui declara-se as vitorias da equipa	

        public int J { get; set; }//Aqui declara-se os jogos da equipa

        public int E { get; set; }//Aqui declara-se os empates da equipa

        public int D { get; set; }//Aqui declara-se as derrotas da equipa

        public int GM { get; set; }//Aqui declara-se os golos marcados da equipa

        public int GS { get; set; }//Aqui declara-se os golos sofridos da equipa

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public User User { get; set; }
        
    }
    
}

