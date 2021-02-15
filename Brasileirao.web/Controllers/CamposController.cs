using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brasileirao.web.Models;
using Brasileirao.web.Models.IEntities;
using Brasileirao.web.Models.Repository;

namespace Brasileirao.web.Controllers
{
    public class CamposController : Controller
    {
       
        private readonly DataContext _context;
        private readonly ICampoRepository _CampoRepository;

        public CamposController(ICampoRepository campoRepository, DataContext context)
        {
            
            _context = context;
            _CampoRepository = campoRepository;
        }

        // GET: Campos
        public async Task<IActionResult> Index()
        {
            return View(_CampoRepository.GetAll());
        }

        // GET: Campos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo = await _CampoRepository.GetByIdAsync(id.Value);
            if (campo == null)
            {
                return NotFound();
            }

            return View(campo);
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var campo = await _context.Campos
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (campo == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(campo);
        }

        // GET: Campos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,local,capacidade,ImageUrl,Cidade")] Campo campo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campo);
        }

        // GET: Campos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo = await _context.Campos.FindAsync(id);
            if (campo == null)
            {
                return NotFound();
            }
            return View(campo);
        }

        // POST: Campos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,local,capacidade,ImageUrl,Cidade")] Campo campo)
        {
            if (id != campo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampoExists(campo.Id))
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
            return View(campo);
        }

        // GET: Campos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo = await _context.Campos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campo == null)
            {
                return NotFound();
            }

            return View(campo);
        }

        // POST: Campos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campo = await _context.Campos.FindAsync(id);
            _context.Campos.Remove(campo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampoExists(int id)
        {
            return _context.Campos.Any(e => e.Id == id);
        }
    }
}
