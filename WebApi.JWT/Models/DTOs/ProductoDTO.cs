namespace WebApi.JWT.Models.DTOs
{
    public class ProductoDTO
    {
        public string? Nombre { get; set; }

        public string? Marca { get; set; }

        public decimal? Precio { get; set; }

        public bool Estado { get; set; }
    }
}
