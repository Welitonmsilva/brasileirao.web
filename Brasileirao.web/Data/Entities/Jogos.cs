

namespace Brasileirao.web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Jogos :IEntity
    {
        public int Id { get; set; }

        public string Jornadas { get; set; }

        public string Clube { get; set; }

        public int Pontos { get; set; }

        public int Posicao { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Ultimo Jogo")]
        public DateTime ultimoJogo { get; set; }

    }
}
