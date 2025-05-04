using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Un pseudo est requis.")]
        [MinLength(3, ErrorMessage = "Le pseudo doit contenir au moins 3 caractères.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Un email est requis.")]
        [EmailAddress(ErrorMessage = "Le format de l'email est invalide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Un mot de passe est requis")]
        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string Password { get; set; }
    }
}
