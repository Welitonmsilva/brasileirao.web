using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Cidade :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public int populacao { get; set; }
        public User User { get; set; }      
        
    }
}
