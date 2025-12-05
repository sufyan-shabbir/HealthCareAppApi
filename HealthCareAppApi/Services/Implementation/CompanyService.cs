using AutoMapper;
using BCrypt.Net;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;

namespace HealthCareAppApi.API.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        } 

         
    }
}
