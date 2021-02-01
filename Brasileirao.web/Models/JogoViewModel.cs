

namespace Brasileirao.web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    public class JogoViewModel : Jogo
    {
        [Display(Name = "Imagem")]
        public IFormFile ImageFile { get; set; }

    }
}
