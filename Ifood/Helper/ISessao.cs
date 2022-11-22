using Ifood.Models;

namespace Ifood.Helper
{
    public interface ISessao
    {

        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
        int GetIdUsuario();
    }
}
