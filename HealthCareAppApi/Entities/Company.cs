using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.API.Entities
{
    public class Company : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ContactInfo { get; set; }
        public bool? IsActive { get; set; }

        // Navigation
        public ICollection<User>? Users { get; set; }
        public ICollection<Role>? Roles { get; set; }
    }
}