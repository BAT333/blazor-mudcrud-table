using System.ComponentModel.DataAnnotations;

namespace RegisteWeb.DTO
{
    public record CreateCustomerDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCustomerDTO(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }
        public CreateCustomerDTO()
        {

        }



    }
}
