using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.Auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Veuillez renseigner votre email.")]
        [EmailAddress(ErrorMessage = "Le format de l'email n'est pas valide.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Veuillez renseigner votre mot de passe.")]
        public string Password { get; set; }
    }
}
