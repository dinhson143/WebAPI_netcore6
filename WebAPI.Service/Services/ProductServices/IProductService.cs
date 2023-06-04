using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Request.ProductDTOs;
using WebAPI.Model.Response.ProductDTOs;
using WebAPI.Repository.Paging;

namespace WebAPI.Service.Services.ProductServices
{
    public interface IProductService
    {
        Task<bool> AddAsync(ProductCreateDTO request);
        Task<bool> UpdateAsync(int id, ProductEditDTO request);
        Task<ProductDetailDTO> GetAsync(int id);
        Task<PagingResult<ProductDetailDTO>> GetByCategoryId(int categoryId, PagingRequest pagingRequest);
        Task<PagingResult<ProductDetailDTO>> GetPagingAsync(PagingRequest pagingRequest);
        Task<List<ProductDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
