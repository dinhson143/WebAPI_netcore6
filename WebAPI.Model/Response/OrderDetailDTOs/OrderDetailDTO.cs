using WebAPI.Model.Response.ProductDTOs;

namespace WebAPI.Model.Response.OrderDetailDTOs
{
    public class OrderDetailDTO
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public ProductDTO Product { set; get; }
    }
}
