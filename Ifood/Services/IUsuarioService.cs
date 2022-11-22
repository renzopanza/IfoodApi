using Ifood.Models;

namespace Ifood.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> BuscarPorLogin(string login);
        Task<UsuarioModel> CadastrarUsuario(UsuarioModel user);
    }
}
