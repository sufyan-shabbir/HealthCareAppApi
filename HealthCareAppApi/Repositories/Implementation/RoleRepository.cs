using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace HealthCareAppApi.API.Repositories.Implementation
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext context, IMapper mapper)
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
