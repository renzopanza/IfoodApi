using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly IRestauranteService restauranteService;
        private readonly IProdutoService produtoService;
        private readonly IPedidoService pedidoService;
        private readonly ISessao sessao;
        private string caminhoDiretorio;

        public RestaurantesController(IRestauranteService restauranteService, ISessao sessao, IWebHostEnvironment sistema, IProdutoService produtoService, IPedidoService pedidoService)
        {
            this.restauranteService = restauranteService;
            this.sessao = sessao;
            caminhoDiretorio = sistema.WebRootPath;
            this.produtoService = produtoService;
            this.pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            if (sessao.BuscarSessao() == null) return RedirectToAction("Index", "Login");

            var restaurantes = await restauranteService.ListarRestaurantes();

            return View(restaurantes);
        }

        public async Task<IActionResult> Criar()
        {
            if (sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");

            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            var restaurante = restauranteService.RestaurantePorId(id);
            return View(restaurante);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(RestauranteModel restaurante)
        {
            await restauranteService.AddRestaurante(restaurante, caminhoDiretorio);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRestaurante(RestauranteModel restaurante)
        {
            await restauranteService.Update(restaurante.IdRestaurante, restaurante);
            return RedirectToAction("Index");
        }
        [Route("/Restaurantes/GetProdutos/idRestaurante-{idRestaurante}")]
        [HttpGet]
        public async Task<IActionResult> GetProdutos(int idRestaurante)
        {

            if (sessao.BuscarSessao() == null) return RedirectToAction("Index", "Login");

            var restaurante = await restauranteService.RestaurantePorId(idRestaurante);
            restauranteService.AtualizarProdutos(idRestaurante);

            return View(restaurante);
        }

        [Route("/Restaurantes/CriarProduto/idRestaurante-{idRestaurante}")]
        public async Task<IActionResult> CriarProduto(int idRestaurante)
        {
            if (sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");

            return View();
        }


        [Route("/Restaurantes/CriarProduto/idRestaurante-{idRestaurante}")]
        [HttpPost]
        public async Task<IActionResult> CriarProduto(int idRestaurante, ProdutoModel produto)
        {
            var addProduto = await produtoService.AddProduto(idRestaurante, produto, caminhoDiretorio);

            if (addProduto == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Restaurantes");
        }

        [HttpGet("/Restaurantes/Comprar/idProduto-{idProduto}")]
        public async Task<IActionResult> Comprar(int idProduto)
        {
            return View();
        }


        [HttpPost("/Restaurantes/Comprar/idProduto-{idProduto}")]
        public async Task<IActionResult> Comprar(int idProduto, PedidoModel pedido)
        {

            int idUsuario = sessao.GetIdUsuario();
            if (idUsuario != -1)
            {
                var addPedido = await pedidoService.CriarPedido(idProduto, idUsuario, pedido);
                if (addPedido == null)
                {
                    return RedirectToAction("Index", "Restaurantes");
                }

                return RedirectToAction("Index");
            }

            return Ok(idUsuario);

        }
    }
}

