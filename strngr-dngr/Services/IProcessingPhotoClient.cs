using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;
using System.Threading.Tasks;

namespace strngr_dngr.Services
{
    public interface IPhotoProcessingClient
	{
		Task<ImageKnowledge> ProcessPhoto(byte[] photoData);
	}
}
