using System;

namespace WebAPI.Repository.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime DateCreated { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}