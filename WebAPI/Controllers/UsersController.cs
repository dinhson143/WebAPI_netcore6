using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.UserDTOs;
using WebAPI.Repository.Constants;
using WebAPI.Service.Services.UserServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserCreateDTO request)
        {
            try
            {
                var result = await _userService.AddAsync(request);
                if(result)
                    return HandleResult(Ok(), StatusRequest.Actions.Add);
                return HandleResult(result, StatusRequest.Actions.AddFailed);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await _userService.GetAsync(id);
                return HandleResult(model, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userService.GetAllAsync();
                return HandleResult(models, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UserEditDTO request)
        {
            try
            {
                await _userService.UpdateAsync(id, request);
                return HandleResult(Ok(), StatusRequest.Actions.Update);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return HandleResult(Ok(), StatusRequest.Actions.Delete);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName, string passWord)
        {
            try
            {
                var token = await _userService.LoginAsync(userName, passWord);
                return HandleResult(token, StatusRequest.Actions.Get);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }
    }
}
