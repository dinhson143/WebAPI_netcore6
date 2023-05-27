using WebAPI.Repository.Enums;

namespace WebAPI.Model.Response.UserDTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public Status Status { get; set; }
    }
}
