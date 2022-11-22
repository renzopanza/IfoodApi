using Ifood.Models;

namespace Ifood.Services
{
    public interface IPedidoService
    {

        Task<List<PedidoModel>> ListarPedidos();

        Task<UsuarioModel> UsuarioPorId(int id);
        void AtualizarPedidos(int idUsuario);
        Task<PedidoModel> CriarPedido(int idProduto, int idUsuario, PedidoModel pedido);
    }
}