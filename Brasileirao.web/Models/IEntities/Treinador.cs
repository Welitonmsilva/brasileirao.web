using Brasileirao.web.Models.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models
{
    public class Treinador : IEntity
    {
        [Key]
        public int id_treinador { get; set; }
        public int num_b_i { get; set; }
        public string nome { get; set; }
        public int Id { get; set; }
    }
}

