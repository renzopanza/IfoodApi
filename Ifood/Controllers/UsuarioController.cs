using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService usuarioService;

        private readonly ISessao sessao;

        public UsuarioController(IUsuarioService usuarioRepositorio, ISessao sessao)
        {
            this.usuarioService = usuarioRepositorio;
            this.sessao = sessao;
        }

        [Route("Cadastro")]
        public IActionResult Index()
        {
            if (sessao.BuscarSessao() != null) return RedirectToAction("Home", "Restaurantes");

            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioModel user)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    
                    UsuarioModel usuario =  await usuarioService.CadastrarUsuario(user);

                    if (usuario == null) {
                        TempData["MensagemErro"] = $"Dados já existente! Informe os dados novamente!";
                        return View("Index");
                    }
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Login");
                }

                return View("Index" ,user);
                
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
