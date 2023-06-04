using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Request.UserDTOs;
using WebAPI.Model.Response.UserDTOs;
using WebAPI.Model.Utilities;

namespace WebAPI.Service.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserCreateDTO request);
        Task<bool> UpdateAsync(int id, UserEditDTO request);
        Task<UserDTO> GetAsync(int id);
        Task<List<UserDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<string> LoginAsync(string userName, string passWord);
    }
}
