using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.ProductDTOs;
using WebAPI.Model.Response.ProductDTOs;
using WebAPI.Repository.Constants;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Paging;
using WebAPI.Repository.UnitOfWork;

namespace WebAPI.Service.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddAsync(ProductCreateDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = _mapper.Map<Product>(request);
                await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when adding product. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id);
                if (product == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                await _unitOfWork.ProductRepository.RemoveAsync(product);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when deleting product. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<ProductDTO>>(await _unitOfWork.ProductRepository.GetAllAsyncNoPaging());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ProductDetailDTO> GetAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(s => s.Id == id);
                if (product == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                return _mapper.Map<ProductDetailDTO>(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<PagingResult<ProductDetailDTO>> GetByCategoryId(int categoryId, PagingRequest pagingRequest)
        {
            try
            {
                var paginatedList = _mapper.Map<PaginatedList<Product>, PaginatedList<ProductDetailDTO>>(await _unitOfWork.ProductRepository.GetProductByCategoryId(categoryId, pagingRequest));

                var pageResult = new PagingResult<ProductDetailDTO>()
                {
                    TotalCount = paginatedList.TotalCount,
                    PageSize = paginatedList.PageSize,
                    TotalPages = paginatedList.TotalPages,
                    CurrentPage = paginatedList.CurrentPage,
                    Objects = paginatedList
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get All Products of category Paging failed in service", nameof(GetByCategoryId));
                throw;
            }
        }

        public async Task<PagingResult<ProductDetailDTO>> GetPagingAsync(PagingRequest pagingRequest)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync(pagingRequest);
                if (products.Count == 0)
                    throw new NotFoundException(StatusRequest.NotFound);
                var productsDTO = _mapper.Map<List<ProductDetailDTO>>(products);
                var pagingResult = new PagingResult<ProductDetailDTO>()
                {
                    TotalPages = products.TotalPages,
                    PageSize = products.PageSize,
                    TotalCount = products.TotalCount,
                    CurrentPage = products.CurrentPage,
                    Objects = productsDTO
                };
                return pagingResult;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                {
                    throw new BadRequestException(StatusRequest.NOT_MATCH);
                }
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == request.Id);
                if (product == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }
                if(product.Name != request.Name && request.Name != null)
                {
                    product.Name = request.Name;
                }
                if (product.Description != request.Description && request.Description != null)
                {
                    product.Description = request.Description;
                }
                if (product.Image != request.Image && request.Image != null)
                {
                    product.Image = request.Image;
                }
                if (product.Stock != request.Stock && request.Stock > -1)
                {
                    product.Stock = request.Stock;
                }
                if (product.ViewCount != request.ViewCount && request.ViewCount > -1)
                {
                    product.ViewCount = request.ViewCount;
                }
                if (product.Price != request.Price && request.Price > -1)
                {
                    product.Price = request.Price;
                }

                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when updating product. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
