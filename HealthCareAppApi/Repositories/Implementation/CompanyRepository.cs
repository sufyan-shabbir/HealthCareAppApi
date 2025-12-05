using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Entities;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 

namespace HealthCareAppApi.API.Repositories.Implementation
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly IMapper _mapper;

        public CompanyRepository(ApplicationDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }
    }
}
