using Newtonsoft.Json;
using strngr_dngr.Model.Request;
using strngr_dngr.Model.Response;
using strngr_dngr.Model.Response.Incandescent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace strngr_dngr.Services
{
    public interface IIncandescentApiService
    {
        object GetReverseImageResults(IEnumerable<string> urls);
    }

    public class IncandescentApiService : IIncandescentApiService
    {
        private readonly string AddRequestUrl = "https://incandescent.xyz/api/add/";
        private readonly string GetRequestUrl = "https://incandescent.xyz/api/get/";
        private readonly int MaxRetryCount = 5;
        
        public object GetReverseImageResults(IEnumerable<string> urls)
        {
            var projectId = GetProjectId(urls);
            Thread.Sleep(5000);
            return GetReverseImageResults(projectId);
        }

        private string GetProjectId(IEnumerable<string> urls)
        {
            var request = CreateAddRequest(urls);
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var addResponse = reader.ReadToEnd();
                var jsonAddResponse = JsonConvert.DeserializeObject<IncandescentAddImageResponse>(addResponse);

                return jsonAddResponse.ProjectId;
            }
        }

        private object GetReverseImageResults(string projectId)
        {
            object results = null;
            bool retry = true;
            int retries = 0;
            
            while (retry && retries < MaxRetryCount)
            {
                var request = CreateGetRequest(projectId);
                var response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var getResponse = reader.ReadToEnd();

                    // Check for error status
                    var jsonStatusResponse = JsonConvert.DeserializeObject<IncandescentStatusResponse>(getResponse);
                    retry = jsonStatusResponse.Status.Equals(710);
                    
                    results = JsonConvert.DeserializeObject(getResponse);

                    if (retry)
                    {
                        retries++;
                        Thread.Sleep(2000);
                    }
                }
            }

            return results;
        }

        private WebRequest CreatePostRequest(string requestUrl, string jsonPayload)
        {
            var request = WebRequest.Create(requestUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = jsonPayload.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            requestWriter.Write(jsonPayload);
            requestWriter.Close();
            return request;
        }

        private WebRequest CreateAddRequest(IEnumerable<string> urls) 
        {
            var payload = JsonConvert.SerializeObject(new IncandescentAddImageRequest(urls));
            return CreatePostRequest(AddRequestUrl, payload);
        }
        
        private WebRequest CreateGetRequest(string projectId)
        {
            var payload = JsonConvert.SerializeObject(new IncandescentGetRequest(projectId));
            return CreatePostRequest(GetRequestUrl, payload);
        }
    }

}
