using AutoFixture;
using strngr_dngr.Model.Request;
using strngr_dngr.Model.Response.OffenderLookup;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace strngr_dngr.Services
{
    public interface IOffenderLookupService
    {
        Task<OffenderLookupResponse> OffenderIdentityCheck(IdentityCheckRequest request);
    }

    public class OffenderLookupService : IOffenderLookupService
    {
        private readonly IFixture _fixture;

        private readonly ConcurrentBag<string> CrimeDescriptions;

        public OffenderLookupService()
        {
            _fixture = new Fixture();

            // Mock descriptions
            CrimeDescriptions = new ConcurrentBag<string>();
            CrimeDescriptions.Add("Changed Nicole's desktop background when she wasn't looking");
            CrimeDescriptions.Add("Stole a donut from Nicole");
            CrimeDescriptions.Add("Ate the last piece of pizza when Nicole was hangry");

        }

        /// <summary>
        /// http://xmlapi.backgroundcheckapi.com/?App_ID=[BACKGROUND CHECK API APP ID]&App_Key=[BACKGROUND CHECK API APP KEY]&Timestamp=[CURRENT TIMESTAMP]&IP=[IP]&catalogue=BACKGROUND&FirstName= Neal Anderson &LastName= Stanford &MiddleName=&State= Washington &County= Benton &City= STEILACOOM &BirthYear=&CrimeType=&ExactMatch=Yes
        /// </summary>

        public async Task<OffenderLookupResponse> OffenderIdentityCheck(IdentityCheckRequest request)
        {
            // Mocked data for now

            return await Task.Run(() => BuildMockData(request));
        }

        private async Task<OffenderLookupResponse> BuildMockData(IdentityCheckRequest request)
        {
            var names = request.Name.Split(' ');
            var firstName = names.Length > 0 ? names[0] : "";
            var lastName = names.Length > 1 ? names.Last() : "";

            var random = new Random();
            var age = random.Next(20, 50);

            var crime = CrimeDescriptions.Take(1).FirstOrDefault();

            return _fixture.Build<OffenderLookupResponse>()
                .With(x => x.City, request.City)
                .With(x => x.FirstName, firstName)
                .With(x => x.LastName, lastName)
                .With(x => x.State, request.StateCode)
                .With(x => x.BirthYear, DateTime.Now.AddYears(-age).Year)
                .With(x => x.Type, CrimeType.Warrant)
                .With(x => x.Description, crime)
                .Create();
        }
    }
}
