using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<Order>> _logger;

        public OrderRepository(MyContext context, ILogger<Repository<Order>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
