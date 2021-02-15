﻿

namespace Brasileirao.web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Brasileirao.web.Models.IEntities;
    public class CampoViewModel : Jogo
    {
        [Display(Name = "Imagem")]
        public IFormFile ImageFile { get; set; }

    }
}
