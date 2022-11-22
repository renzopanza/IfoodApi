using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ifood.Models
{
    public class PedidoModel
    {
        [Key()]
        public int IdPedido { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public ProdutoModel Produto { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }

        [ForeignKey("Restaurante")]
        public int IdRestaurante { get; set; }
        public RestauranteModel Restaurante { get; set; }

        public DateTime DataPedido { get; set; }
    }
}
