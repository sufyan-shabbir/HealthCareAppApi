using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace HealthCareAppApi.API.Repositories.Implementation
{
    public class LookupRepository : GenericRepository<Lookup>, ILookupRepository
    {
        private readonly IMapper _mapper;

        public LookupRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<User> GetQueryable()
        {
            return _context.Set<User>().AsQueryable();
        }

        public async Task<List<Lookup>> GetAllByFormAndCodeAsync(int formNameId, string code)
        {
            return await _context.Set<Lookup>()
                .Where(x => x.FormNameId == formNameId && x.Code == code && x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();
        }
    }
}
