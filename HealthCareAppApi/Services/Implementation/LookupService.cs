using AutoMapper;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAppApi.API.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IFunctionRepository _functionRepository; 

        public LookupService(
            IUnitOfWork uow,
            IMapper mapper,
            IFunctionRepository functionRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _functionRepository = functionRepository; 
        }

        //public async Task<ResponseModel<List<LookupResponseDto>>> GetAllByFormAndCodeAsync(int formNameId, string code)
        //{
        //    var lookups = await _uow.lookupRepository.GetAllByFormAndCodeAsync(formNameId, code);
        //    var mapped = _mapper.Map<List<LookupResponseDto>>(lookups);

        //    return new ResponseModel<List<LookupResponseDto>>(mapped, 200, "Success", 1);
        //}


    }
}
