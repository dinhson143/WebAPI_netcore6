using System;
using WebAPI.Repository.Enums;

namespace WebAPI.Model.Request.CartDTOs
{
    public class CartEditDTO
    {
        public int Id { get; set; }
        public int Quantity { set; get; }
    }
}
