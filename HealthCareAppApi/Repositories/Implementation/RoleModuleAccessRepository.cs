using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace HealthCareAppApi.API.Repositories.Implementation
{
    public class RoleModuleAccessRepository : GenericRepository<RoleModuleAccess>, IRoleModuleAccessRepository
    {
        private readonly IMapper _mapper;

        public RoleModuleAccessRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<Role> GetQueryable()
        {
            return _context.Set<Role>().AsQueryable();
        }
    }
}
