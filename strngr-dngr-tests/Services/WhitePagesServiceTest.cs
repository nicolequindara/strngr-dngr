using strngr_dngr.Services;
using System.Threading.Tasks;
using strngr_dngr.Model.Request;
using Xunit;

namespace strngr_dngr_tests.Services
{
    public class WhitePagesServiceTest
    {
        private readonly IWhitePagesApiService _whitePagesApiService;

        public WhitePagesServiceTest()
        {
            _whitePagesApiService = new WhitePagesApiService();

        }

        [Fact]
        public async Task ReverseAddress()
        {
            // Act
            var actual = await _whitePagesApiService.ReverseAddress(new ReverseAddressRequest
            {
                StreeLine1 = "8750 N Central Expy",
                City = "Dallas",
                StateCode = "TX",
                PostalCode = "75231"
            });

            Assert.NotNull(actual);
        }
    }
}
