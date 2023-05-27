namespace WebAPI.Model.Request.OrderDTOs
{
    public class OrderEditDTO
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public decimal Tongtien { set; get; }
    }
}
