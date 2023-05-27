using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.CartDTOs;
using WebAPI.Model.Request.CategoryDTOs;
using WebAPI.Model.Response.CartDTOs;
using WebAPI.Model.Response.CategoryDTOs;
using WebAPI.Repository.Constants;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Paging;
using WebAPI.Repository.UnitOfWork;

namespace WebAPI.Service.Services.CartServices
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CartService> _logger;
        public CartService(IUnitOfWork unitOfWork, 
            IMapper mapper,
            ILogger<CartService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddAsync(CartCreateDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var category = _mapper.Map<Category>(request);
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when adding category. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }

        }

        public async Task<bool> UpdateAsync(int id, CartEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                {
                    throw new BadRequestException(StatusRequest.NOT_MATCH);
                }
                var cart = await _unitOfWork.CartRepository.GetAsync(x => x.Id == request.Id);
                if (cart == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                cart.Quantity = request.Quantity;
                await _unitOfWork.CartRepository.UpdateAsync(cart);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when updating cart. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<CartDTO> GetAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.CartRepository.GetAsync(s => s.Id == id);
                if (category == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                return _mapper.Map<CartDTO>(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<CartDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<CartDTO>>(await _unitOfWork.CartRepository.GetAllAsyncNoPaging());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var cart = await _unitOfWork.CartRepository.GetAsync(x => x.Id == id);
                if (cart == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                await _unitOfWork.CartRepository.RemoveAsync(cart);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when deleting cart. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
