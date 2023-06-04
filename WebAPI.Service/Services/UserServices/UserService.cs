using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Model.Exceptions;
using WebAPI.Model.Request.UserDTOs;
using WebAPI.Model.Response.UserDTOs;
using WebAPI.Model.Utilities;
using WebAPI.Repository.Constants;
using WebAPI.Repository.Entities;
using WebAPI.Repository.UnitOfWork;

namespace WebAPI.Service.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        public UserService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<UserService> logger,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            IConfiguration config
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<bool> AddAsync(UserCreateDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = _mapper.Map<User>(request);
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded && result.Errors.Count() < 1)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    await trans.CommitAsync();
                    return true;
                }
                else
                    _logger.LogError($"Has en error when adding user. {result.Errors.ToString()}");
                    return false;         
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when adding user. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.UserRepository.GetAsync(x => x.Id == id);
                if (user == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                await _unitOfWork.UserRepository.RemoveAsync(user);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when deleting user. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            try
            {
                return _mapper.Map<List<UserDTO>>(await _unitOfWork.UserRepository.GetAllAsyncNoPaging());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetAsync(s => s.Id == id);
                if (user == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<string> LoginAsync(string userName, string passWord)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(userName.ToString()));
                }
                var result = await _signInManager.PasswordSignInAsync(user, passWord, true, false);
                if (!result.Succeeded)
                {
                    throw new NotFoundException(StatusRequest.LoginFailed);
                }
                var role = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Role, role.ToString()),
                    new Claim(ClaimTypes.DateOfBirth, user.Dob?.ToString("MM/dd/yyyy")),
                    new Claim(ClaimTypes.StreetAddress,user.Address),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // token issuer: 16 kí tự
                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                    _config["Tokens:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when login user. {e.InnerException?.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, UserEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                {
                    throw new BadRequestException(StatusRequest.NOT_MATCH);
                }
                var user = await _unitOfWork.UserRepository.GetAsync(x => x.Id == request.Id);
                if (user == null)
                {
                    throw new NotFoundException(StatusRequest.RESOURCE_NOTFOUND(id.ToString()));
                }

                if (user.LastName != request.LastName && request.LastName != null)
                {
                    user.LastName = request.LastName;
                }
                if (user.FirstName != request.FirstName && request.FirstName != null)
                {
                    user.FirstName = request.FirstName;
                }
                if (user.Address != request.Address && request.Address != null)
                {
                    user.Address = request.Address;
                }
                if (user.Dob != request.Dob && request.Dob != null)
                {
                    user.Dob = request.Dob;
                }
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Has en error when updating user. {e.InnerException?.Message}");
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
