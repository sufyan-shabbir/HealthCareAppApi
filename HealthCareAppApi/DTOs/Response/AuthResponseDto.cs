namespace HealthCareAppApi.DTOs.Response
{
    public class AuthResponseDto
    {
        public string? Token { get; set; }
        public object? User { get; set; }
        public List<RoleModuleAccessResponse>? Permissions { get; set; }
    }
}
