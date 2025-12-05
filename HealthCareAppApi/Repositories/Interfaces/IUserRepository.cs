using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Repositories.Interfaces; 

namespace HealthCareAppApi.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<User> GetQueryable();
    }
}
