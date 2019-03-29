using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using strngr_dngr.Model.Request;
using strngr_dngr.Model.Response.OffenderLookup;

namespace strngr_dngr.Services
{
	public interface IOffenderLookupService
	{
		Task<OffenderLookupResponse> OffenderIdentityCheck(IdentityCheckRequest request);
	}

	public class OffenderLookupService : IOffenderLookupService
	{
		public async Task<OffenderLookupResponse> OffenderIdentityCheck(IdentityCheckRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
