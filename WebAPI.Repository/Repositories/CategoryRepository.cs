using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<Category>> _logger;

        public CategoryRepository(MyContext context, ILogger<Repository<Category>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
