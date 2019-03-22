using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using strngr_dngr.Services;

namespace Tests
{
	public class PhotoProcessingClientTests
	{
		private PhotoProcessingClient _client;
		private string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "..\\..\\..\\..";

		[SetUp]
		public void Setup()
		{
			_client = new PhotoProcessingClient();
		}

		[TestCase("/Images/pikachu.jpg")]
		public void Client_CanMakeRequest_AndGetResponse(string fileLocation)
		{
			var bytes = File.ReadAllBytes(basePath+fileLocation);
			var response = _client.ProcessPhoto(bytes);
			response.Should().NotBeNull();
		}
	}
}