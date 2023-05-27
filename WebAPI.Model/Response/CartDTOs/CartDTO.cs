using System;

namespace WebAPI.Model.Response.CartDTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { set; get; }
    }
}
