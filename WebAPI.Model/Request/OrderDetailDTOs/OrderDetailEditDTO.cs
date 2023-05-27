namespace WebAPI.Model.Request.OrderDetailDTOs
{
    public class OrderDetailEditDTO
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
    }
}
