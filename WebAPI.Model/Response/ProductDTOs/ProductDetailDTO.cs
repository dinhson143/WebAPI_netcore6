namespace WebAPI.Model.Response.ProductDTOs
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int ViewCount { get; set; }
        public decimal Price { get; set; }
    }
}
