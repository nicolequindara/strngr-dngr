using Microsoft.AspNetCore.Mvc;
using strngr_dngr.Model.Request;
using strngr_dngr.Services;
using System.Threading.Tasks;

namespace strngr_dngr.Controllers
{
    [Route("api/[controller]")]
    public class WhitePagesController : Controller
    {
        private readonly IWhitePagesApiService _whitePagesApiService;


        public WhitePagesController(IWhitePagesApiService whitePagesApiService)
        {
            _whitePagesApiService = whitePagesApiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ReverseAddress([FromBody] ReverseAddressRequest request)
        {
            if (request == null) return BadRequest();
            return Ok(await _whitePagesApiService.ReverseAddress(request));
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> IdentityCheck([FromBody] IdentityCheckRequest request)
        {
            if (request == null) return BadRequest();
            return Ok(await _whitePagesApiService.IdentityCheck(request));
        }
    }
}