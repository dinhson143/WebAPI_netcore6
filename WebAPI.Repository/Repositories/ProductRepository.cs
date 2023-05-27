using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

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
    }
}
