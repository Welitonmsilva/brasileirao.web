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
    public class JogosController : Controller
    {
        private IJogoRepository jogorepository;

        public JogosController(IJogoRepository jogoRepository)
        {
            _jogorepository = jogoRepository;
        }
        

        // GET: Jogos
        public IActionResult Index()
        {
            return View(Jogosrepository.GetJogos());
        }

        // GET: Jogos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = _Jogosrepository.GetJogos(id.Value);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jornadas,Clube,Pontos,Posicao,ImageUrl,ultimoJogo")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                _Jogosrepository.Addjogos(jogos);
                await _Jogosrepository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = _Jogosrepository.GetJogos(id.Value);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jornadas,Clube,Pontos,Posicao,ImageUrl,ultimoJogo")] Jogos jogos)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _Jogosrepository.updateJogos(jogos);
                    await _Jogosrepository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await  _Jogosrepository.ExistAsync(jogos.Id))
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
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = _Jogosrepository.GetJogos(id.Value);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogos = _Jogosrepository.GetJogos(id);
            _Jogosrepository.Removejogos(jogos);
            await _Jogosrepository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
