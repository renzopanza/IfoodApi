using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ifood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestauranteService restauranteService;
        private readonly ISessao sessao;

        public HomeController(ILogger<HomeController> logger, ISessao sessao, IRestauranteService restauranteService)
        {
            _logger = logger;
            this.sessao = sessao;
            this.restauranteService = restauranteService;
        }

        public  async Task<IActionResult>Index()
        {
            if (sessao.BuscarSessao() != null) return RedirectToAction("Index", "Restaurantes");
            var restaurantes = await restauranteService.ListarRestaurantes();
            return View(restaurantes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}