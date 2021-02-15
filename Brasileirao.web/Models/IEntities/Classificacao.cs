using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Classificacao : IEntity
    {
        public int Id { get; set; }       
        public int Posicao { get; set; }//Aqui declara-se a posição da equipa
        public string NomeEquipa { get; set; }//Aqui declara-se o nome da equipa
        public int Pts { get; set; }//Aqui declara-se os pontos da equipa
        public int V { get; set; }//Aqui declara-se as vitorias da equipa	
        public int J { get; set; }//Aqui declara-se os jogos da equipa
        public int E { get; set; }//Aqui declara-se os empates da equipa
        public int D { get; set; }//Aqui declara-se as derrotas da equipa
        public int GM { get; set; }//Aqui declara-se os golos marcados da equipa
        public int GS { get; set; }//Aqui declara-se os golos sofridos da equipa




    }
}
