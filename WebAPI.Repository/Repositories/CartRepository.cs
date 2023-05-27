using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<Cart>> _logger;

        public CartRepository(MyContext context, ILogger<Repository<Cart>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
