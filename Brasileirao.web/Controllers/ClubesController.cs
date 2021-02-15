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
    public class ClubesController : Controller
    {
        private readonly DataContext _context;

        public ClubesController(DataContext context)
        {
            _context = context;
        }

        // GET: Clubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clubes.ToListAsync());
        }

        // GET: Clubes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clube = await _context.Clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clube == null)
            {
                return NotFound();
            }

            return View(clube);
        }

        // GET: Clubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,ImageUrl,cidade,campo")] Clube clube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clube);
        }

        // GET: Clubes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clube = await _context.Clubes.FindAsync(id);
            if (clube == null)
            {
                return NotFound();
            }
            return View(clube);
        }

        // POST: Clubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,ImageUrl,cidade,campo")] Clube clube)
        {
            if (id != clube.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubeExists(clube.Id))
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
            return View(clube);
        }

        // GET: Clubes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clube = await _context.Clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clube == null)
            {
                return NotFound();
            }

            return View(clube);
        }

        // POST: Clubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clube = await _context.Clubes.FindAsync(id);
            _context.Clubes.Remove(clube);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubeExists(int id)
        {
            return _context.Clubes.Any(e => e.Id == id);
        }
    }
}
