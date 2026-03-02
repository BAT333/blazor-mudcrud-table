using System.ComponentModel.DataAnnotations;

namespace RegisteWeb.DTO
{
    public record LoginCustomerDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "A password deve conter pelo menos uma letra maiúscula e um caractere especial.")]
        public string Password { get; set; }

        public bool UseCookies { get; set; } = true;

        public LoginCustomerDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public LoginCustomerDTO()
        {
        }


    }
}
