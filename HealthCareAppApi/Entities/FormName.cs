using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.API.Entities
{
    public class FormName : BaseEntity
    {
        public string? Name { get; set; }

        // Navigation
        public ICollection<Lookup>? Lookups { get; set; }
    }
}