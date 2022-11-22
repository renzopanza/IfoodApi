using Ifood.Data;
using Ifood.Helper;
using Ifood.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ifood.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly RobinContext context;
        private readonly ISessao sessao;

        public PedidoService(RobinContext context, ISessao sessao)
        {
            this.context = context;
            this.sessao = sessao;
        }


        public async Task<PedidoModel> CriarPedido(int idProduto, int idUsuario, PedidoModel pedido)
        {
            ProdutoModel produto = context.Produtos.FirstOrDefault(x => x.IdProduto == idProduto);
            UsuarioModel usuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
            RestauranteModel restaurante = context.Restaurantes.FirstOrDefault(x => x.IdRestaurante == produto.IdRestaurante);

            if (produto != null && usuario != null && restaurante != null)
            {
                pedido.Produto = produto;
                pedido.Usuario = usuario;
                pedido.Restaurante = restaurante;

                pedido.DataPedido = DateTime.Now;
                context.Pedidos.Add(pedido);
                await context.SaveChangesAsync();
                return pedido;
            }

            return null;
        }

        public async Task<List<PedidoModel>> ListarPedidos()
        {
            List<PedidoModel> pedidos = await context.Pedidos.ToListAsync();
            return pedidos;
        }

        public async Task<UsuarioModel> UsuarioPorId(int id)
        {
            return await context.Usuarios.FindAsync(id);
        }

        public async void AtualizarPedidos(int idUsuario)
        {
            
            var pedidosList = context.Pedidos.ToList();

            foreach (PedidoModel pedido in pedidosList)
            { 
                if (pedido.IdUsuario == idUsuario)
                {
                    var usuario = await UsuarioPorId(idUsuario);

                    var produto = context.Produtos.Find(pedido.IdProduto);
                    var restaurante = context.Restaurantes.Find(pedido.IdRestaurante);

                    if (produto != null && restaurante != null)
                    {
                        pedido.Produto = produto;
                        pedido.Restaurante = restaurante;
                    }
                    usuario.Pedidos.Add(pedido);

                }
            }
        }
    }
}
