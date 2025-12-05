using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.DTOs.Request;
using HealthCareAppApi.DTOs.Response;
using HealthCareAppApi.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthCareAppApi.API.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(ApplicationDbContext context, IJwtService jwtService, IPasswordHasher<User> passwordHasher,IEmailService emailService, IUserService userService, IRoleService roleService )
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _userService = userService;
            _roleService = roleService;
        }


        public async Task<AuthResponseDto?> LoginAsync(AuthRequestDto request)
        {
            var user = await _context.ApplicationUser
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.EmailOrUsername || u.UserName == request.EmailOrUsername);

            if (user == null)
                return null;

            bool isPasswordValid = PasswordHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid)
                return null;

            var moduleAccesses = await _context.roleModuleAccess
                .Where(rm => rm.RoleId == user.RoleId)
                .Include(rm => rm.Module)
                .ToListAsync() ?? new List<RoleModuleAccess>();


            var userResponse = await _userService.GetUserByIdAsync(user.Id);

            var permissionResponse = await _roleService.GetPermissionsByRoleIdAsync(user.RoleId);

            var token = _jwtService.GenerateToken(user, user.Role!, moduleAccesses);
            var permissions = permissionResponse?.Result ?? new List<RoleModuleAccessResponse>();

            if (userResponse == null || userResponse.Result == null)
            {
                return new AuthResponseDto
                {
                    Token = token,
                    User = null,
                    Permissions = permissions
                };
            }

            return new AuthResponseDto
            {
                Token = token,
                User = userResponse.Result,
                Permissions = permissions
            };
        }

        //public async Task ForgotPasswordAsync(string email)
        //{
        //    var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Email == email);
        //    if (user == null) throw new Exception("User not found");

        //    // Generate token & expiry
        //    user.ResetPasswordToken = Guid.NewGuid().ToString();
        //    user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(15);
        //    await _context.SaveChangesAsync();

        //    // Create reset link
        //    string resetLink = $"http://localhost:4200/auth/reset-password?token={user.ResetPasswordToken}&email={user.Email}";

        //    // Send email
        //    await _emailService.SendPasswordResetEmail(user.Email, resetLink); // Use actual user email
        //}

        //public async Task ResetPasswordAsync(string email, string token, string newPassword)
        //{
        //    var user = await _context.ApplicationUser
        //        .FirstOrDefaultAsync(u => u.Email == email && u.ResetPasswordToken == token);

        //    if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
        //        throw new Exception("Invalid or expired token");

        //    var (hash, salt) = PasswordHelper.HashPassword(newPassword);

        //    user.PasswordHash = hash;
        //    user.PasswordSalt = salt;   
        //    user.ResetPasswordToken = null;
        //    user.ResetTokenExpiry = null;

        //    await _context.SaveChangesAsync();
        //}
    }
}