using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models
{
    public class Clube : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        public string nome { get; set; }

        public string cidade  { get; set; }

        public string campo { get; set; }

        //public int treinador { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public User User { get; set; }






    }
}
