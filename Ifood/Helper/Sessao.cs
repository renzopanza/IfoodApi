using Ifood.Models;
using Newtonsoft.Json;

namespace Ifood.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessao()
        {
            string sessao = _httpContext.HttpContext.Session.GetString("usuarioLogado");

            if (string.IsNullOrEmpty(sessao)) return null;


            return JsonConvert.DeserializeObject<UsuarioModel>(sessao);
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("usuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _httpContext.HttpContext.Session.Remove("usuarioLogado");
        }

        public int GetIdUsuario()
        {
            string sessao = _httpContext.HttpContext.Session.GetString("usuarioLogado");

            if (string.IsNullOrEmpty(sessao)) return -1;


            return JsonConvert.DeserializeObject<UsuarioModel>(sessao).IdUsuario;
        }
    }
}
