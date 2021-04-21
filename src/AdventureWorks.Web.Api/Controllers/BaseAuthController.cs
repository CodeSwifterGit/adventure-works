using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Api.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public abstract class BaseAuthController : ControllerBase
    {
    }
}