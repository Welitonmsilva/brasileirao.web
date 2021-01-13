using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brasileirao.web.Data;
using Brasileirao.web.Data.Entities;

namespace Brasileirao.web.Controllers
{
    public class clubesController : Controller
    {
        private readonly DataContext _context;

        public clubesController(DataContext context)
        {
            _context = context;
        }

        // GET: clubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.clubes.ToListAsync());
        }

        // GET: clubes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubes = await _context.clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubes == null)
            {
                return NotFound();
            }

            return View(clubes);
        }

        // GET: clubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,ImageUrl,cidade,Nome_campo")] clubes clubes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clubes);
        }

        // GET: clubes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubes = await _context.clubes.FindAsync(id);
            if (clubes == null)
            {
                return NotFound();
            }
            return View(clubes);
        }

        // POST: clubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,ImageUrl,cidade,Nome_campo")] clubes clubes)
        {
            if (id != clubes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clubesExists(clubes.Id))
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
            return View(clubes);
        }

        // GET: clubes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubes = await _context.clubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubes == null)
            {
                return NotFound();
            }

            return View(clubes);
        }

        // POST: clubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubes = await _context.clubes.FindAsync(id);
            _context.clubes.Remove(clubes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clubesExists(int id)
        {
            return _context.clubes.Any(e => e.Id == id);
        }
    }
}
