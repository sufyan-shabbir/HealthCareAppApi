
using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.DTOs.Response
{ 
    public class RoleModuleAccessResponse
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
