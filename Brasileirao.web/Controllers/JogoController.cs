using Brasileirao.web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Brasileirao.web.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IClassificacaoRepository _classificacao;

        public JogoController(IClassificacaoRepository classificacaoRepository, 
            IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
            _classificacao = classificacaoRepository;
        }

        

        public IActionResult List()
        {
            //ViewBag.Jogo = "Jogos";
            //ViewData["Classificacao"] = "Classificacao";

            var jogos = _jogoRepository.Jogos;
            return View(jogos);

        }
    }
   
}
