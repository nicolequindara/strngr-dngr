using Microsoft.AspNetCore.Mvc;
using strngr_dngr.Services;

namespace strngr_dngr.Controllers
{
    public class PhotoProcessingController : Controller
    {
        private readonly IPhotoProcessingClient _photoClient;
        public PhotoProcessingController(IPhotoProcessingClient client)
        {
            _photoClient = client;
        }

		[HttpPost, Route("api/photo/test")]
        public IActionResult Test()
        {
            return Ok(new JsonResult(new { success = true }));
        }

        [HttpGet("imageknowledge")]
        public IActionResult GetProcessedPhotoData(byte[] imageData)
        {
            var photoResults = _photoClient.ProcessPhoto(imageData);
            //TODO figure out what to return from this

            return Ok();
        }
    }
}
