using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.IEntities
{
    public class Clube
    {
        public int clubeId { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string ImageURl { get; set; }
        public string Campo { get; set; }
   
    }
}
