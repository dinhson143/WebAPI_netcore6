namespace WebAPI.Model.Request.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }
}
