using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Models.Repository
{
    public class Repository : IRepository
    {

        private readonly DataContext _context;


        public Repository(DataContext context)
        {
            _context = context;
        }


        //Método que vai buscar os produtos todos
        public IEnumerable<Jogo> GetProducts()
        {
            return _context.Jogos.OrderBy(p => p.Name);
        }


        //Método que vai buscar um produto pelo id
        public Jogo GetProduct(int id)
        {
            return _context.Jogos.Find(id);
        }


        //Método que adiciona um produto á tabela
        public void AddProduct(Jogo Jogo
            )
        {
            _context.Jogos.Add(Jogo);
        }


        //Método que atualiza (update) um produto
        public void UpdateProduct(Jogo Jogo)
        {
            _context.Update(Jogo);
        }


        //Método que remove um produto
        public void RemoveProduct(Jogo Jogo)
        {
            _context.Jogos.Remove(Jogo);
        }


        //Método que atualiza a BD
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        //Método que verifica se o produto existe
        public bool ProductExists(int Id)
        {
            return _context.Jogos.Any(p => p.Id == Id);
        }
    }

    public interface IRepository
    {
    }
}
