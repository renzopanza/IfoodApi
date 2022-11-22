using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class PedidosController : Controller
    {

        private readonly IPedidoService pedidoService;
        private readonly ISessao sessao;

        public PedidosController(IPedidoService pedidoService, ISessao sessao)
        {
            this.pedidoService = pedidoService;
            this.sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            if (sessao.BuscarSessao() == null) { return RedirectToAction("Index", "Login"); }

            var idUsuario = sessao.GetIdUsuario();
            if (idUsuario != -1)
            {
                var usuario = await pedidoService.UsuarioPorId(idUsuario);

                if (usuario != null)
                {
                    pedidoService.AtualizarPedidos(idUsuario);
                    return View(usuario);
                }

                return RedirectToAction("Index", "Restaurantes");
            }

            return BadRequest("USUARIO NÂO LOGADO!");
        }
    }
}
