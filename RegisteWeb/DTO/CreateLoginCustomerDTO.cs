using System.ComponentModel.DataAnnotations;

namespace RegisteWeb.DTO
{
    public record CreateLoginCustomerDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(8, ErrorMessage = "O nome não pode ter mais de 8 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Introduza um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        [StringLength(30, ErrorMessage = "A password deve ter entre 8 e 30 caracteres.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repita a password.")]
        [Compare(nameof(Password), ErrorMessage = "As passwords não coincidem.")]
        public string PasswordCompare { get; set; }
    }
}
