using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class BaseApiController : ControllerBase
    {
    }
}
