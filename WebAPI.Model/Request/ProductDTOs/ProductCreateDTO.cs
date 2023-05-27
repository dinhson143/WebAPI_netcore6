namespace WebAPI.Model.Request.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int ViewCount { get; set; }
        public decimal Price { get; set; }
    }
}
