using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioService usuarioService;
        private readonly ISessao sessao;

        public LoginController(IUsuarioService usuarioRepositorio, ISessao sessao)
        {
            this.usuarioService = usuarioRepositorio;
            this.sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se usuário estiver logado redirecionarar para a home

            if (sessao.BuscarSessao() != null) return RedirectToAction("Index", "Restaurantes");

            return View();
        }

        public IActionResult Sair()
        {
            sessao.RemoverSessao();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = await usuarioService.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"senha inválida.";
                        TempData["MensagemErroSpan"] = "Por favor, digite novamente!";

                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s).";
                    TempData["MensagemErroSpan"] = "Por favor, digite novamente!";
                    
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
