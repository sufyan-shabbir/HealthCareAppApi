


using HealthCareAppApi.DTOs.Request;
using HealthCareAppApi.DTOs.Response;
using HealthCareAppApi.Http;

namespace HealthCareAppApi.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel<ApplicationUserResponse>> SaveUserAsync(ApplicationUserRequest request);
        Task<ResponseModel<object>> GetUserByIdAsync(int userId);
    }
}
