using WebAPI.Model.Request.CartDTOs;
using WebAPI.Model.Response.CartDTOs;
using WebAPI.Repository.Paging;

namespace WebAPI.Service.Services.CartServices
{
    public interface ICartService
    {
        Task<bool> AddAsync(CartCreateDTO request);
        Task<bool> UpdateAsync(int id, CartEditDTO request);
        Task<CartDTO> GetAsync(int id);
        Task<List<CartDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
