using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Paging;

namespace WebAPI.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<PaginatedList<Product>> GetProductByCategoryId(int categoryId, PagingRequest pagingRequest);
    }
}
