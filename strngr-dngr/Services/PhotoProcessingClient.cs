using Microsoft.Azure.CognitiveServices.Search.VisualSearch;
using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using System.IO;
using System.Threading.Tasks;

namespace strngr_dngr.Services
{
    public class PhotoProcessingClient : IPhotoProcessingClient
    {
        private VisualSearchClient _client;

        public PhotoProcessingClient()
        {
            _client = new VisualSearchClient(new ApiKeyServiceClientCredentials("6126fc4406c541a4bc4347f571c49215"));
        }

        public async Task<ImageKnowledge> ProcessPhoto(byte[] photoData)
        {
            Stream stream = new MemoryStream(photoData);
            // The knowledgeRequest parameter is not required if an image binary is passed in the request body
            var visualSearchResults = await _client.Images.VisualSearchMethodAsync(image: stream, knowledgeRequest: (string)null);
            //var image = visualSearchResults.Image;
            //var tags = visualSearchResults.Tags;
            //var readLink = visualSearchResults.ReadLink;
            //var url = visualSearchResults.WebSearchUrl;
            return visualSearchResults;
        }
    }
}
