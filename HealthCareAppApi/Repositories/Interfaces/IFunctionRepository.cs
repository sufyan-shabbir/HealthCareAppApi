 

namespace HealthCareAppApi.Repositories.Interfaces
{
    public interface IFunctionRepository
    {
        Task<object> GetUserByIdAsync(int userId);
    }
}
