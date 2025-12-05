using AutoMapper;
using BCrypt.Net;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAppApi.API.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public MenuService(IUnitOfWork uow, IMapper mapper, ApplicationDbContext context)
        {
            _uow = uow;
            _mapper = mapper;
            _context = context;
        }
         

    }
}
