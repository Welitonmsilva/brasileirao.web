using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brasileirao.web.Models;
using Brasileirao.web.Models.IEntities;

namespace Brasileirao.web.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly DataContext _context;

        public JogadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Jogadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogogadores.ToListAsync());
        }

        // GET: Jogadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogogadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // GET: Jogadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,num_B_I,nome,morada,idade,ImageUrl,Clube,Posicao,Cidade")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogador);
        }

        // GET: Jogadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogogadores.FindAsync(id);
            if (jogador == null)
            {
                return NotFound();
            }
            return View(jogador);
        }

        // POST: Jogadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,num_B_I,nome,morada,idade,ImageUrl,Clube,Posicao,Cidade")] Jogador jogador)
        {
            if (id != jogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadorExists(jogador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jogador);
        }

        // GET: Jogadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogador = await _context.Jogogadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogador == null)
            {
                return NotFound();
            }

            return View(jogador);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogador = await _context.Jogogadores.FindAsync(id);
            _context.Jogogadores.Remove(jogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadorExists(int id)
        {
            return _context.Jogogadores.Any(e => e.Id == id);
        }
    }
}
