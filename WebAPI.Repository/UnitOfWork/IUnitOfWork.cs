using Microsoft.EntityFrameworkCore.Storage;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICartRepository CartRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IUserRepository UserRepository { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        bool CheckAlreadyTransaction();
        Task<int> SaveAsync();
    }
}
