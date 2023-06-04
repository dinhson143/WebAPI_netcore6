namespace WebAPI.Model.Request.UserDTOs
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
    }
}
