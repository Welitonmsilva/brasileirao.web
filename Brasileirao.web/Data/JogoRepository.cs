using Brasileirao.web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Data
{
    public class JogoRepository : GenericRepository<Jogo>, IJogoRepository
    {
        private readonly DataContext _context;
        public JogoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Getjogos()
        {
            var list = _context.Jogos.Select(p => new SelectListItem
            {
                Text = p.Clube,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a product...)",
                Value = "0"
            });


            return list;
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
