using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Take.Challenge.Api
{
    public class BaseClienteApi
    {

        public readonly string UrlBase;

        protected Uri ServiceUri
        {
            get
            {
                return new Uri(CombineUri(UrlBase, string.Empty));
            }
        }

        public BaseClienteApi(string urlBase)
        {
            UrlBase = urlBase;            
        }

        protected async Task<T> Get<T>(Uri url)
        {
            var value = await Get(url);
            return JsonConvert.DeserializeObject<T>(value);
        }

        protected async Task<string> Get(Uri url)
        {
            using (var client = await GetHttpClient())
            {
                var result = await client.GetAsync(url);
                return await GetResult(result);
            }
        }    

        protected async Task<string> GetResult(HttpResponseMessage result)
        {              
            return await result.Content.ReadAsStringAsync();
        }

        private async Task<HttpClient> GetHttpClient()
        {
            return await Task.Run(() =>
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = this.ServiceUri;

                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "request");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            });
        }

        private string CombineUri(string uriBase, params string[] uriParts)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(uriBase);

            var foundSlash = uriBase.EndsWith("/");
            for (int i = 0; i < uriParts.Length; i++)
            {
                if (!foundSlash)
                    sb.Append("/");

                sb.Append(uriParts[i]);
                foundSlash = uriParts[i].EndsWith("/");
            }
            return sb.ToString();
        }
    }
}
