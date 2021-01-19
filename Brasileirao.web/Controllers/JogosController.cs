using Brasileirao.web.Data;
using Brasileirao.web.Data.Entities;
using Brasileirao.web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.web.Controllers
{
    public class JogosController : Controller
    {
        private readonly IJogoRepository _Jogorepository;
        private readonly IUserHelper _userHelper;

        public JogosController(IJogoRepository jogoRepository, IUserHelper userHelpers)
        {
            _Jogorepository = jogoRepository;
            _userHelper = userHelpers;
        }


        // GET: Jogos
        public IActionResult Index()
        {
            return View(_Jogorepository.Getall()/*.OrderBy(p => p.Clube)*/);
        }

        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await  _Jogorepository.GetbyIdAsync(id.Value);
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
        public async Task<IActionResult> Create([Bind("Id,Jornadas,Clube,Pontos,Posicao,ImageUrl,ultimoJogo")] Jogo jogos)
        {
            if (ModelState.IsValid)
            {
                await _Jogorepository.CreateAsync(jogos);                
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _Jogorepository.GetbyIdAsync(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jornadas,Clube,Pontos,Posicao,ImageUrl,ultimoJogo")] Jogo jogos)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _Jogorepository.UpdateAsync(jogos);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _Jogorepository.ExistsAsync(jogos.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _Jogorepository.GetbyIdAsync(id.Value);
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
            var jogos = await _Jogorepository.GetbyIdAsync(id);
            await _Jogorepository.DeleteAsync(jogos);          
            return RedirectToAction(nameof(Index));
        }


    }
}
