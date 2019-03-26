using Microsoft.AspNetCore.Mvc;
using strngr_dngr.Services;
using System.Collections.Generic;

namespace strngr_dngr.Controllers
{
    [Route("api/[controller]")]
    public class ReverseImageSearchController : Controller
    {
        private readonly IIncandescentApiService _incandescentApiService;

        public ReverseImageSearchController(IIncandescentApiService incandescentApiService)
        {
            _incandescentApiService = incandescentApiService;
        }

        [HttpPost("[action]")]
        public IActionResult Search([FromBody] IEnumerable<string> urls)
        {
            return Ok(_incandescentApiService.GetReverseImageResults(urls));
        }



    }
}