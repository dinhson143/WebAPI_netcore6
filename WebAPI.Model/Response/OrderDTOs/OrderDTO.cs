using WebAPI.Model.Response.OrderDetailDTOs;
using WebAPI.Repository.Enums;

namespace WebAPI.Model.Response.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { set; get; }
        public int UserId { set; get; }

        public DateTime OrderDate { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public decimal Tongtien { set; get; }
        public OrderStatus Status { set; get; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
