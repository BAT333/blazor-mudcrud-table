using System.ComponentModel.DataAnnotations;

namespace RegisteWeb.DTO
{
    public record UpdateCustomerDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }

        public UpdateCustomerDTO(string name, string description, DateTime now)
        {
            Name = name;
            Description = description;
            this.CreatedDate = now;
        }
        public UpdateCustomerDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
