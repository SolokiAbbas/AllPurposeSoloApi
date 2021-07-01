using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AllPurpose.Logic
{
    public class GeneralApiClient: Models.IGeneralApiClient
    {
        private HttpClient Client { get; }
        public GeneralApiClient(IHttpClientFactory httpClientFactory)
        {
            Client = CreateHttpClient(httpClientFactory);
        }

        private HttpClient CreateHttpClient(IHttpClientFactory httpClientFactory)
        {
            var client = httpClientFactory.CreateClient("GeneralApi");
            client.BaseAddress = new Uri("https://www.google.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            return client;
        }

        public async Task<string> GetRequest(string url)
        {
            
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            using var resp = await Client.SendAsync(httpMessage);

            var stream = new MemoryStream();
            await resp.Content.CopyToAsync(stream);
            stream.Position = 0;
            var responseBody = string.Empty;
            using(var reader = new StreamReader(stream))
            {
                responseBody = reader.ReadToEnd() ?? string.Empty;
            }
            return responseBody;
        }

        public async Task<string> PostRequest(string url, object obj)
        {
            var uri = new Uri(url);
            using var resp = await Client.PostAsync(uri, CreateJsonContent(obj));

            var stream = new MemoryStream();
            await resp.Content.CopyToAsync(stream);
            stream.Position = 0;
            var responseBody = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                responseBody = reader.ReadToEnd() ?? string.Empty;
            }
            return responseBody;
        }

        private HttpContent CreateJsonContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var content = new StreamContent(ms);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            return content;
        } 
    }
}
