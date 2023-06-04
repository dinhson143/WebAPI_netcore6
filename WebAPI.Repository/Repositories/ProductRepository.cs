using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;
using WebAPI.Repository.Paging;

namespace WebAPI.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<Product>> _logger;

        public ProductRepository(MyContext context, ILogger<Repository<Product>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<Product>> GetProductByCategoryId(int categoryId, PagingRequest pagingRequest)
        {
            try
            {
                //var paginatedList = await GetAllAsync(pagingRequest, n => (n.UserId == userId && n.IsDelete == false), n => n.User);
                var products = from p in _context.Products
                               join pc in _context.ProductInCategories on p.Id equals pc.ProductId
                               where pc.CategoryId == categoryId
                               select p;


                var paginatedList = await PaginatedList<Product>.ToPaginatedListAsync(products, pagingRequest.PageNumber, pagingRequest.PageSize);
                return paginatedList;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All products of category Paging failed", nameof(GetProductByCategoryId));
                throw;
            }
        }
    }
}
