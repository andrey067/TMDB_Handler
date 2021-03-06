using System.ComponentModel.DataAnnotations;

namespace Tmdb.API.ViewModels
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
        [MaxLength(80, ErrorMessage = "O email deve ter no máximo 180 caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "A senha deve ter no máximo 20 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Data de aniversaio não pode ser vazia.")]
        public DateTime Birthday { get; set; }
    }
}
