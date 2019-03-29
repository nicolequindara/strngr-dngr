using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using Newtonsoft.Json;
using strngr_dngr.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace strngr_dngr.Controllers
{
    [Route("api/[controller]")]
    public class PhotoProcessingController : Controller
    {
        private readonly IPhotoProcessingClient _photoClient;
        public PhotoProcessingController(IPhotoProcessingClient client)
        {
            _photoClient = client;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetProcessedPhotoData()
        {
            var resp = new List<ImageKnowledge>();
            foreach (var photo in Request.Form.Files)
            {
                using (var binaryReader = new BinaryReader(photo.OpenReadStream()))
                {
                    var bytes = binaryReader.ReadBytes((int)photo.Length);
                    resp.Add(await _photoClient.ProcessPhoto(bytes));
                }
            }

            return Ok(resp);
        }
    }
}
