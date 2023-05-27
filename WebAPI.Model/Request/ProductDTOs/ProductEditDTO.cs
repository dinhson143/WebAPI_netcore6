using WebAPI.Repository.Enums;

namespace WebAPI.Model.Request.ProductDTOs
{
    public class ProductEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int ViewCount { get; set; }
        public decimal Price { get; set; }
    }
}
