using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Veuillez renseigner votre email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Veuillez renseigner votre mot de passe.")]
        public string Password { get; set; }
    }
}
