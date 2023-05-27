using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.CategoryDTOs;
using WebAPI.Model.Response.CategoryDTOs;
using WebAPI.Repository.Constants;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Paging;
using WebAPI.Repository.UnitOfWork;

namespace WebAPI.Service.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IUnitOfWork unitOfWork, 
            IMapper mapper,
            ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddAsync(CategoryCreateDTO request)
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

        public async Task<bool> UpdateAsync(int id, CategoryEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                {
                    throw new BadRequestException(StatusRequest.NOT_MATCH);
                }
                var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == request.Id);
                if (category == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                category.Name = request.Name;
                category.Status = request.IsActive;
                await _unitOfWork.CategoryRepository.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when updating category. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<CategoryDetailDTO> GetAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetAsync(s => s.Id == id);
                if (category == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                return _mapper.Map<CategoryDetailDTO>(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<PagingResult<CategoryDetailDTO>> GetPagingAsync(PagingRequest pagingRequest)
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync(pagingRequest);
                if (categories.Count == 0)
                    throw new NotFoundException(StatusRequest.NotFound);
                var categoriesDTO = _mapper.Map<List<CategoryDetailDTO>>(categories);
                var pagingResult = new PagingResult<CategoryDetailDTO>()
                {
                    TotalPages = categories.TotalPages,
                    PageSize = categories.PageSize,
                    TotalCount = categories.TotalCount,
                    CurrentPage = categories.CurrentPage,
                    Objects = categoriesDTO
                };
                return pagingResult;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<CategoryDTO>>(await _unitOfWork.CategoryRepository.GetAllAsyncNoPaging());
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
                var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
                if (category == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                await _unitOfWork.CategoryRepository.RemoveAsync(category);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when deleting category. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
