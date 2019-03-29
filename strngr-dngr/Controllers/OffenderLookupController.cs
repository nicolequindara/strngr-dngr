using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using strngr_dngr.Model.Request;
using strngr_dngr.Services;

namespace strngr_dngr.Controllers
{

	[Route("api/[controller]")]
	public class OffenderLookupController : Controller
	{
		private readonly IOffenderLookupService _offenderLookup;
		public OffenderLookupController(IOffenderLookupService offenderLookup)
		{
			_offenderLookup = offenderLookup;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Search([FromBody] IdentityCheckRequest request)
		{
			if (request == null) return BadRequest();
			return Ok(await _offenderLookup.OffenderIdentityCheck(request));
		}
	}
}
