using Microsoft.AspNetCore.Mvc;

namespace BloodTrack.Api.Controllers
{
    [ApiController]
    [Route("api/v1/bloodstocks")]
    public class BloodStocksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
