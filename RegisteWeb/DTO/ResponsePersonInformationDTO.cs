namespace RegisteWeb.DTO
{
    public record ResponsePersonInformationDTO
    {
        public string? Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
