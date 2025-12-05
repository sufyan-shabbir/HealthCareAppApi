
using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.DTOs.Response
{ 
    public class RoleDetailResponse : RoleResponse
    {
        public List<RoleModuleAccessResponse> ModuleAccesses { get; set; } = new();
    }
      
}
