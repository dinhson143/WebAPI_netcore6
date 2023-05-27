namespace WebAPI.Model.Request.UserDTOs
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
    }
}
