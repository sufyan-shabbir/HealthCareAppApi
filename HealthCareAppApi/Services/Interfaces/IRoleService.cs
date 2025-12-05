


using HealthCareAppApi.DTOs.Response;
using HealthCareAppApi.Http;

namespace HealthCareAppApi.API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<ResponseModel<List<RoleModuleAccessResponse>>> GetPermissionsByRoleIdAsync(int roleId);
    }
}
