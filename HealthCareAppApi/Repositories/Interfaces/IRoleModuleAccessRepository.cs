

using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Repositories.Interfaces;

namespace HealthCareAppApi.Repositories.Interfaces
{
    public interface IRoleModuleAccessRepository : IGenericRepository<RoleModuleAccess>
    {
        IQueryable<Role> GetQueryable();
    }
}
