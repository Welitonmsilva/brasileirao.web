using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data.Entities
{
    public class clubes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        public string Nome_campo { get; set; }
    }
}
