using System.ComponentModel.DataAnnotations;

namespace Tmdb.API.ViewModels
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O email não pode vazio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Password { get; set; }
    }
}