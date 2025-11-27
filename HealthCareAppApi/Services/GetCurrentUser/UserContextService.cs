using System.Security.Claims;

namespace Kutiyana_Memon_Hospital_Api.API.Services.GetCurrentUser
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext == null || httpContext.User == null)
                    return null;

                var userIdClaim = httpContext.User.FindFirst("sub");
                if (userIdClaim == null)
                    return null;

                if (int.TryParse(userIdClaim.Value, out var userId))
                    return userId;

                return null;
            }
        }


    }
}
