using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brasileirao.web.Models;
using System.IO;
using Brasileirao.web.Helpers;
using Brasileirao.web.Models.Repository;

namespace Brasileirao.web.Controllers
{
    public class JogosController : Controller
    {
        private readonly IJogoRepository _JogoRepository;
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;

        public JogosController(DataContext context, IJogoRepository jogoRepository, IUserHelper userHelper)
        {
            _context = context;
            _JogoRepository = jogoRepository;
            _userHelper = userHelper;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogos.ToListAsync());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
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
        public async Task<IActionResult> Create(JogoViewModel view)
        {
            if (ModelState.IsValid)
            { 

                var path = string.Empty;



               if (view.ImageFile != null && view.ImageFile.Length > 0)
               {
                    path = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot\\images\\Jogos", view.ImageFile.FileName);


                     using (var stream = new FileStream(path, FileMode.Create))
                     {
                         await view.ImageFile.CopyToAsync(stream);
                     }

                        path = $"~/Images/Jogos{view.ImageFile.FileName}";  
               }
                var jogo = this.ToJogo(view, path);

                ////var product = this.ToProduct(view, path);
                ////TODO: Mudar para o user que depois tiver logado
                ////Jogo.User = await _userHelper.GetUserByEmailAsync("");
                ////await _JogoRepository.CreateAsync(Jogo);
                ////return RedirectToAction(nameof(Index));
                ////Jogo.User = await this.UserHeper.GetUserByEmailAsync("weliton.mesquita.silva@formandos.cinel.pt");
                await _JogoRepository.CreateAsync(jogo);
                return RedirectToAction(nameof(Index));
                //if (ModelState.IsValid)
                //{
                //    _context.Add(jogo);
                //    await _context.SaveChangesAsync();
                //    return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Jogo ToJogo(JogoViewModel view, string path)
        {
            return new Jogo
            {
                Id = view.Id,
                ImageUrl = path,
                Jornadas = view.Jornadas,
                Clube = view.Clube,
                Pontos = view.Pontos,
                Posicao = view.Posicao,
                Name = view.Name,
                User = view.User
            };
        }

        //private Jogo ToJogo(JogoViewModel view, string path)
        //{
        //    return new Jogo
        //    {
        //        Id = view.Id,
        //        ImageUrl = path,
        //        Jornadas = view.Jornadas,
        //        Clube = view.Clube,
        //        Pontos = view.Pontos,
        //        Posicao = view.Posicao,
        //        Name = view.Name,
        //        User = view.User
        //    };
        //}

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var jogo = await _context.Jogos.FindAsync(id);
            var jogo = await this._JogoRepository.GetByIdAsync(id.Value);
            if (jogo == null)
            {
                return NotFound();
            }
            var view = this.ToJogoViewModel(jogo);
            return View(view);
        }

        private JogoViewModel ToJogoViewModel(Jogo jogo)
        {
            return new JogoViewModel
            {
                Id = jogo.Id,
                ImageUrl = jogo.ImageUrl,
                Jornadas = jogo.Jornadas,
                Clube = jogo.Clube,
                Pontos = jogo.Pontos,
                Posicao = jogo.Posicao,
                Name = jogo.Name,
                User = jogo.User
            };
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jornadas,Clube,Pontos,Posicao,ImageUrl,Name")] Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoExists(jogo.Id))
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
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogo = await _context.Jogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }

            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoExists(int id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
