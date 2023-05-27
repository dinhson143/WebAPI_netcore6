namespace WebAPI.Model.Response.CartDTOs
{
    public class CartDetailDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime DateCreated { get; set; }
    }
}
