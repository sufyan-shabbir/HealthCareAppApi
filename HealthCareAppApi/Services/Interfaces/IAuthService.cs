using HealthCareAppApi.DTOs.Request;
using HealthCareAppApi.DTOs.Response; 

namespace HealthCareAppApi.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(AuthRequestDto request);
        ////Task ForgotPasswordAsync(string email);
        //Task ResetPasswordAsync(string email, string token, string newPassword);
    }
}
