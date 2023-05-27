using WebAPI.Model.Request.CategoryDTOs;
using WebAPI.Model.Response.CategoryDTOs;
using WebAPI.Repository.Paging;

namespace WebAPI.Service.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(CategoryCreateDTO request);
        Task<bool> UpdateAsync(int id, CategoryEditDTO request);
        Task<CategoryDetailDTO> GetAsync(int id);
        Task<PagingResult<CategoryDetailDTO>> GetPagingAsync(PagingRequest pagingRequest);
        Task<List<CategoryDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
