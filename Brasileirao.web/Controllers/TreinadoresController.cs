using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brasileirao.web.Models;

namespace Brasileirao.web.Controllers
{
    public class TreinadoresController : Controller
    {
        private readonly DataContext _context;

        public TreinadoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Treinadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Treinadores.ToListAsync());
        }

        // GET: Treinadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores
                .FirstOrDefaultAsync(m => m.id_treinador == id);
            if (treinador == null)
            {
                return NotFound();
            }

            return View(treinador);
        }

        // GET: Treinadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treinadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_treinador,num_b_i,nome,Id")] Treinador treinador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treinador);
        }

        // GET: Treinadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores.FindAsync(id);
            if (treinador == null)
            {
                return NotFound();
            }
            return View(treinador);
        }

        // POST: Treinadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_treinador,num_b_i,nome,Id")] Treinador treinador)
        {
            if (id != treinador.id_treinador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinadorExists(treinador.id_treinador))
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
            return View(treinador);
        }

        // GET: Treinadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinador = await _context.Treinadores
                .FirstOrDefaultAsync(m => m.id_treinador == id);
            if (treinador == null)
            {
                return NotFound();
            }

            return View(treinador);
        }

        // POST: Treinadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinador = await _context.Treinadores.FindAsync(id);
            _context.Treinadores.Remove(treinador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinadorExists(int id)
        {
            return _context.Treinadores.Any(e => e.id_treinador == id);
        }
    }
}
