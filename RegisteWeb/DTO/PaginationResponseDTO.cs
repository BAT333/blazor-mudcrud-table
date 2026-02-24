namespace RegisteWeb.DTO
{
    public record PaginationResponseDTO <T>
    {
        public int Total { get; set; }
        public List<T> Items {  get; set; }
    }
}
