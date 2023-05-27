using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int ViewCount { get; set; }
        public decimal Price { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }

    }
}
