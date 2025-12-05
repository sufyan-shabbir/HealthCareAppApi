
using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.DTOs.Response
{
    public class RoleResponse : BaseEntity
    { 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; } 
    }
      
}
