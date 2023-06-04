using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.ProductDTOs;
using WebAPI.Repository.Constants;
using WebAPI.Repository.Paging;
using WebAPI.Service.Services.ProductServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO request)
        {
            try
            {
                await _productService.AddAsync(request);
                return HandleResult(Ok(), StatusRequest.Actions.Add);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Get product details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await _productService.GetAsync(id);
                return HandleResult(model, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _productService.GetAllAsync();
                return HandleResult(models, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get list product paging
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var models = await _productService.GetPagingAsync(pagingRequest);
                return HandleResult(models, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get list product paging by categoryId
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("paging-by-category")]
        public async Task<IActionResult> GetPagingByCategoryId(int categoryId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var models = await _productService.GetByCategoryId(categoryId, pagingRequest);
                return HandleResult(models, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ProductEditDTO request)
        {
            try
            {
                await _productService.UpdateAsync(id, request);
                return HandleResult(Ok(), StatusRequest.Actions.Update);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return HandleResult(Ok(), StatusRequest.Actions.Delete);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }
    }
}
