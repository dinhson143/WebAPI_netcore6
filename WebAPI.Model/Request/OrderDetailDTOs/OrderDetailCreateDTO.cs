namespace WebAPI.Model.Request.OrderDetailDTOs
{
    public class OrderDetailCreateDTO
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}
