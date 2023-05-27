using WebAPI.Repository.Interfaces;
using WebAPI.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebAPI.Repository.EF;

namespace WebAPI.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes
        private readonly MyContext _context;
        private ICategoryRepository _categoryRepository;
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;
        private IOrderDetailRepository _orderdetailRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        #endregion

        #region Logger
        private readonly ILogger<CategoryRepository> _categoryRepositoryLogger;
        private readonly ILogger<CartRepository> _cartRepositoryLogger;
        private readonly ILogger<ProductRepository> _productRepositoryLogger;
        private readonly ILogger<OrderDetailRepository> _orderdetailRepositoryLogger;
        private readonly ILogger<OrderRepository> _orderRepositoryLogger;
        private readonly ILogger<UserRepository> _userRepositoryLogger;


        #endregion

        #region Methods

        public UnitOfWork(MyContext context,
            ILogger<CategoryRepository> categoryRepositoryLogger)
        {
            _context = context;        
            _categoryRepositoryLogger = categoryRepositoryLogger;
        }
        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context, _categoryRepositoryLogger);
        public ICartRepository CartRepository =>
            _cartRepository ??= new CartRepository(_context, _cartRepositoryLogger);
        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context, _productRepositoryLogger);
        public IOrderDetailRepository OrderDetailRepository =>
            _orderdetailRepository ??= new OrderDetailRepository(_context, _orderdetailRepositoryLogger);
        public IOrderRepository OrderRepository =>
            _orderRepository ??= new OrderRepository(_context, _orderRepositoryLogger);
        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_context, _userRepositoryLogger);


        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _context.Database.CurrentTransaction ?? await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool CheckAlreadyTransaction()
        {
            return _context.Database.CurrentTransaction != null;
        }

        #endregion
    }
}