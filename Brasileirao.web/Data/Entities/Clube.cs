using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data.Entities
{
    public class Clube : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
