using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using strngr_dngr.Services;

namespace strngr_dngr.Controllers
{
	public class PhotoProcessingController : Controller
	{
		private IPhotoProcessingClient _photoClient;
		public PhotoProcessingController(IPhotoProcessingClient client)
		{
			_photoClient = client;
		}

		[HttpGet("[action]")]
		public void GetProcessedPhotoData(byte[] imageData)
		{
			var photoResults = _photoClient.ProcessPhoto(imageData);
			//TODO figure out what to return from this
		}
	}
}
