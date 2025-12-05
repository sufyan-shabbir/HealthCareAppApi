using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace HealthCareAppApi.API.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<User> GetQueryable()
        {
            return _context.Set<User>().AsQueryable();
        }
    }
}
