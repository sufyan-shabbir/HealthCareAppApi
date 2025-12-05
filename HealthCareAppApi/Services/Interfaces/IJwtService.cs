
using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.API.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user, Role role, List<RoleModuleAccess> moduleAccesses);
    }
}
