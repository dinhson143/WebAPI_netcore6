using WebAPI.Model.Request.OrderDetailDTOs;
using WebAPI.Repository.Enums;

namespace WebAPI.Model.Request.OrderDTOs
{
    public class OrderCreateDTO
    {
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public decimal Tongtien { set; get; }
        public List<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}
