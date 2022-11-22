using Ifood.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ifood.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }
        [Required]
        [StringLength(55)]
        public string NomeProduto { get; set; } = string.Empty;
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }

        public string? CaminhoImagem { get; set; } = string.Empty;

        public double Preco { get; set; }
        [StringLength(140)]
        public string? Observacoes { get; set; } = string.Empty;

        [ForeignKey("Restaurante")]
        public int IdRestaurante { get; set; }
        public RestauranteModel? Restaurante { get; set; }

    }
}
