using Microsoft.Extensions.Logging;
using WebAPI.Repository.EF;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MyContext _context;
        private readonly ILogger<Repository<User>> _logger;

        public UserRepository(MyContext context, ILogger<Repository<User>> logger) 
            : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
