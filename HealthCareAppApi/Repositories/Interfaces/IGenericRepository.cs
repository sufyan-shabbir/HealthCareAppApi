
using HealthCareAppApi.API.Entities; 
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace HealthCareAppApi.API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByGlobalIdAsync(Guid globalId);
        Task<User?> GetByEmailOrUserNameAsync(string identifier);
        Task AddAsync(T entity);
        void Update(T entity);
        //void Delete(T entity);
        void PermanentDelete(T entity);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddRangeAsync(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
         IQueryable<T> GetAll();
    }
}
