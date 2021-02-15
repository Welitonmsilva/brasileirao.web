using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models
{
    public class Clube : IEntity
    {

        [Key]
        public int Id { get; set; }

        public string nome { get; set; }      

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public User User { get; set; }
       
        public int cidade { get; set; }
       
        public string campo { get; set; }








    }
}
