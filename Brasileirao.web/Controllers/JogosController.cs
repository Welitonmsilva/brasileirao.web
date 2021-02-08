using Brasileirao.web.Helpers;
using Brasileirao.web.Models;
using Brasileirao.web.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Brasileirao.web.Controllers
{
    public class JogosController : Controller
    {
        private readonly IJogoRepository _JogoRepository;
        private readonly IUserHelper _userHelper;


        public JogosController(IJogoRepository JogoRepository, IJogoRepository jogoRepository, IUserHelper userHelper)
        {
          
            _JogoRepository = JogoRepository;
            _userHelper = userHelper;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(_JogoRepository.GetAll());
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Jogo = await _JogoRepository.GetByIdAsync(id.Value);

            if (Jogo == null)
            {
                return NotFound();
            }

            return View(Jogo);
        }
        [Authorize(Roles = "Admin")]
        // GET: Jogos/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
   [HttpPost]
        
        public async Task<IActionResult> Create(JogoViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Jogos",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/jogos/{file}";
                }

                var product = this.ToJogo (view, path);
                product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _JogoRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
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
                User = view.User
            };
        }


        //[Authorize(Roles = "Admin")]
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
                User = jogo.User
            };
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]

        public async Task<IActionResult> Edit(int id, JogoViewModel view)
        {
            if (id != view.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {

                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\jogos",
                        file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/jogos/{file}";
                    }

                    var product = this.ToJogo(view, path);
                    product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _JogoRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _JogoRepository.ExistAsync(view.Id))
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
            return View(view);
        }
        //[Authorize(Roles = "Admin")]
        // GET: Jogos/Delete/5


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Jogo = await _JogoRepository.GetByIdAsync(id.Value);
            if (Jogo == null)
            {
                return NotFound();
            }

            return View(Jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _JogoRepository.GetByIdAsync(id);
            await _JogoRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
