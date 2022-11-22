using Ifood.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ifood.Models
{
    public class UsuarioModel
    {


        [Key()]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuário!")]
        [MaxLength(55)]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o celular do usuário!")]
        [MaxLength(20)]
        public string Celular { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o endereço do usuário!")]
        [MaxLength(255)]
        public string Endereco { get; set; } = string.Empty;
        [MaxLength(200)]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o login do usuário")]
        [MaxLength(30)]
        public string LoginUser { get; set; } = string.Empty;
        [Required(ErrorMessage = "Insira uma senha")]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();


       
        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }

    }
}
