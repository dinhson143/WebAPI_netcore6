using System;
using WebAPI.Repository.Enums;

namespace WebAPI.Model.Request.UserDTOs
{
    public class UserEditDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
    }
}
