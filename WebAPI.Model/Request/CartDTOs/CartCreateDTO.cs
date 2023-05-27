namespace WebAPI.Model.Request.CartDTOs
{
    public class CartCreateDTO
    {
        public int UserId { get; set; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
    }
}
