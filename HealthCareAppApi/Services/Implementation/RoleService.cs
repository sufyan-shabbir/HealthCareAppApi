using AutoMapper;
using HealthCareAppApi.API.Data;
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.API.UnitOfWork.Interfaces;
using HealthCareAppApi.DTOs.Response;
using HealthCareAppApi.Http;
using HealthCareAppApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;


namespace HealthCareAppApi.API.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IFunctionRepository _functionRepository;
        private readonly ApplicationDbContext _context;

        public RoleService(IUnitOfWork uow, IMapper mapper, IFunctionRepository functionRepository, ApplicationDbContext context)
        {
            _uow = uow;
            _mapper = mapper;
            _functionRepository = functionRepository;
            _context = context;

        }

        public async Task<ResponseModel<List<RoleModuleAccessResponse>>> GetPermissionsByRoleIdAsync(int roleId)
        {
            var response = new ResponseModel<List<RoleModuleAccessResponse>>();

            try
            {
                var permissions = await _context.roleModuleAccess
                    .Where(rm => rm.RoleId == roleId)
                    .Include(rm => rm.Module)
                    .Select(rm => new RoleModuleAccessResponse
                    {
                        ModuleId = rm.ModuleId,
                        ModuleName = rm.Module != null ? rm.Module.Name : string.Empty,
                        CanRead = rm.CanRead,
                        CanCreate = rm.CanCreate,
                        CanUpdate = rm.CanUpdate,
                        CanDelete = rm.CanDelete
                    })
                    .ToListAsync();

                response.Result = permissions;
                //response.IsSuccess = true;
                response.Message = "Permissions fetched successfully.";
            }
            catch (Exception ex)
            {
                //response.IsSuccess = false;
                response.Message = $"Error while fetching permissions: {ex.Message}";
            }

            return response;
        }


    }
}
