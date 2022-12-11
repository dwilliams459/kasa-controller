using Microsoft.AspNetCore.Mvc;

namespace Kasa.Web.Api.Controllers
{
    [ApiController]
    [Route("Ping")]

    public class PingController : ControllerBase
    {
        [HttpGet(Name = "Ping")]
        public async Task<string> Get()
        {
            return DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
        }

    }
}
