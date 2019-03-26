using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using strngr_dngr.Services;
using System.Collections.Generic;
using System.IO;

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
        public IActionResult GetProcessedPhotoData()
        {
            var resp = new List<ImageKnowledge>();
            foreach (var photo in Request.Form.Files)
            {
                using (var fs = System.IO.File.Create(photo.FileName))
                {
                    photo.CopyTo(fs);

                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        var imgData = br.ReadBytes((int)fs.Length);
                        resp.Add(_photoClient.ProcessPhoto(imgData));
                    }
                }
            }

            return Ok(resp);
        }
    }
}
