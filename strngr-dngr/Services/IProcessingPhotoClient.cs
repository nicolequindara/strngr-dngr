using Microsoft.Azure.CognitiveServices.Search.VisualSearch.Models;

namespace strngr_dngr.Services
{
	public interface IPhotoProcessingClient
	{
		ImageKnowledge ProcessPhoto(byte[] photoData);
	}
}
