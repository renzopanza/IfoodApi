using System.ComponentModel.DataAnnotations;

namespace Ifood.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login do usuário")]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira uma senha")]
        public string Senha { get; set; }
    }
}
