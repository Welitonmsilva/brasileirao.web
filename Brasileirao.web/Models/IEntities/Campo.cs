using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Campo : IEntity
    {
        [Key]
        public int Id { get; set; }      
      
        public string local { get; set; }
        public int capacidade { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public User User { get; set; }
      
        public int Cidade { get; set; }

    }
}
