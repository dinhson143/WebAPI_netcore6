using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<OrderDetail>> _logger;

        public OrderDetailRepository(MyContext context, ILogger<Repository<OrderDetail>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
