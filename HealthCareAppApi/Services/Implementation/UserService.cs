using AutoMapper;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;
using HealthCareAppApi.DTOs.Request;
using HealthCareAppApi.DTOs.Response;
using HealthCareAppApi.Helpers;
using HealthCareAppApi.Http;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAppApi.API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IFunctionRepository _functionRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(
            IUnitOfWork uow,
            IMapper mapper,
            IFunctionRepository functionRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _uow = uow;
            _mapper = mapper;
            _functionRepository = functionRepository;
            _passwordHasher = passwordHasher;
        }

        //  Create And Update
        public async Task<ResponseModel<ApplicationUserResponse>> SaveUserAsync(ApplicationUserRequest request)
        {
            try
            { 
                if (request.GlobalId == Guid.Empty)
                {
                    // Duplicate checks
                    if (await _uow.userRepository.GetQueryable().AnyAsync(u => u.Email == request.Email && !u.IsDeleted))
                        return new ResponseModel<ApplicationUserResponse> { Result = null, Message = "Email already exists.", HttpStatusCode = 400 };

                    if (await _uow.userRepository.GetQueryable().AnyAsync(u => u.UserName == request.UserName && !u.IsDeleted))
                        return new ResponseModel<ApplicationUserResponse> { Result = null, Message = "Username already exists.", HttpStatusCode = 400 };

                    var user = _mapper.Map<User>(request);
                    user.GlobalId = Guid.NewGuid();

                    var (hash, salt) = PasswordHelper.HashPassword(request.Password);
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;

                    await _uow.userRepository.AddAsync(user);
                    await _uow.SaveChangesAsync();

                    return new ResponseModel<ApplicationUserResponse>
                    {
                        Result = _mapper.Map<ApplicationUserResponse>(user),
                        Message = "User created successfully.",
                        HttpStatusCode = 201
                    };
                }

                // --- UPDATE EXISTING USER ---
                var existingUser = await _uow.userRepository.GetQueryable()
                    .FirstOrDefaultAsync(u => u.GlobalId == request.GlobalId && !u.IsDeleted);

                if (existingUser == null)
                    return new ResponseModel<ApplicationUserResponse> { Result = null, Message = "User not found.", HttpStatusCode = 404 };

                if (!string.IsNullOrWhiteSpace(request.Email) && request.Email != existingUser.Email &&
                    await _uow.userRepository.GetQueryable().AnyAsync(u => u.Email == request.Email && u.GlobalId != request.GlobalId && !u.IsDeleted))
                {
                    return new ResponseModel<ApplicationUserResponse> { Result = null, Message = "Email already exists for another user.", HttpStatusCode = 400 };
                }

                _mapper.Map(request, existingUser);  

                if (!string.IsNullOrWhiteSpace(request.Password))
                {
                    var (hash, salt) = PasswordHelper.HashPassword(request.Password);
                    existingUser.PasswordHash = hash;
                    existingUser.PasswordSalt = salt;
                }

                _uow.userRepository.Update(existingUser);
                await _uow.SaveChangesAsync();

                return new ResponseModel<ApplicationUserResponse>
                {
                    Result = _mapper.Map<ApplicationUserResponse>(existingUser),
                    Message = "User updated successfully.",
                    HttpStatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<ApplicationUserResponse>
                {
                    Result = null,
                    Message = $"Error saving user: {ex.Message}",
                    HttpStatusCode = 500
                };
            }
        }

        //GetById
        public async Task<ResponseModel<object>> GetUserByIdAsync(int userId)
        {
            try
            {
                var userDetail = await _functionRepository.GetUserByIdAsync(userId);

                return new ResponseModel<object>
                {
                    Result = userDetail,
                    Message = userDetail == null ? "User not found." : "User retrieved successfully.",
                    HttpStatusCode = userDetail == null ? 404 : 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<object>
                {
                    Result = null,
                    Message = $"Error fetching role: {ex.Message}",
                    HttpStatusCode = 500
                };
            }
        }

    }
}
