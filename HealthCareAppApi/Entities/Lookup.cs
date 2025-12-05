using HealthCareAppApi.API.Entities;

namespace HealthCareAppApi.API.Entities
{
    public class Lookup : BaseEntity
    {
        //public int CompanyId { get; set; }
        public int FormNameId { get; set; }

        public string Code { get; set; } = string.Empty;  // e.g. "TRANSPORT_MODE"
        public string Name { get; set; } = string.Empty;  // e.g. "Ambulance"
        public int? SortOrder { get; set; }

        // Navigation
        //public Company? Company { get; set; }
        public FormName? FormName { get; set; }
    }
}