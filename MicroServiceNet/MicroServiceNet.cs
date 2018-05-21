using Microsoft.Extensions.Logging;
using Pivotal.Discovery.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MicroServiceNet
{
    public class MicroServiceNet
    {
        private static DiscoveryHttpClientHandler _handler;
        public MicroServiceNet(IDiscoveryClient client, ILoggerFactory logFactory)
        {
            _handler = new DiscoveryHttpClientHandler(client, logFactory.CreateLogger<DiscoveryHttpClientHandler>());
        }

        public static Task<HttpResponseMessage> Execute(Func<List<KeyValuePair<string, string>>, Task<HttpResponseMessage>> method, List<KeyValuePair<string, string>> parameters = null)
        {
            FormUrlEncodedContent encodedContent = null;

            if (parameters != null || parameters.Count > 0)
                encodedContent = new FormUrlEncodedContent(parameters);

            MicroService microService = MicroServiceAttribute.GetMicroService(method);
            Uri MyUri = new Uri(new Uri(MicroServiceHostAttribute.GetMicroService(method)), microService.Name);

            var client = GetClient();

            Task<HttpResponseMessage> result = null;

            switch (microService.Action)
            {


                case HttpMethod act when act == HttpMethod.Get:
                    result = client.GetAsync(MyUri);
                    break;
                case HttpMethod act when act == HttpMethod.Post:
                    result = client.PostAsync(MyUri, encodedContent);
                    break;
                case HttpMethod act when act == HttpMethod.Put:
                    result = client.PutAsync(MyUri, encodedContent);
                    break;
                case HttpMethod act when act == HttpMethod.Delete:
                    result = client.DeleteAsync(MyUri);
                    break;
                default:
                    break;
            }

            return result;
        }

        private static HttpClient GetClient()
        {
            var client = new HttpClient(_handler, false);
            return client;
        }
    }
}
