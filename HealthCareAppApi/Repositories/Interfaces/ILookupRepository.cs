

using HealthCareAppApi.API.Entities;
using HealthCareAppApi.API.Repositories.Interfaces;

namespace HealthCareAppApi.Repositories.Interfaces
{
    public interface ILookupRepository : IGenericRepository<Lookup>
    {
        IQueryable<User> GetQueryable();
        Task<List<Lookup>> GetAllByFormAndCodeAsync(int formNameId, string code);
    }
}
