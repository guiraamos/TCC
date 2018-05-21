using Pivotal.Discovery.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MicroServiceNet
{
    public class MicroServiceBase
    {
        private DiscoveryHttpClientHandler _handler;


        public Task<HttpResponseMessage> Execute<T>(Func<List<KeyValuePair<string, string>>, Task<HttpResponseMessage>> method, HttpVerbs action, List<KeyValuePair<string, string>> parameters = null)
            where T : MicroServiceBase
        {
            FormUrlEncodedContent encodedContent = null;

            if (parameters != null || parameters.Count > 0)
                encodedContent = new FormUrlEncodedContent(parameters);

            Uri MyUri = new Uri(new Uri(MicroServiceHostAttribute.GetMicroService(method)), MicroServiceAttribute.GetMicroService(method).Name);

            var client = new HttpClient(_handler, false);

            Task<HttpResponseMessage> result = null;

            switch (action)
            {
                case HttpVerbs.Get:
                    result = client.GetAsync(MyUri);
                    break;
                case HttpVerbs.Post:
                    result = client.PostAsync(MyUri, encodedContent);
                    break;
                case HttpVerbs.Put:
                    result = client.PutAsync(MyUri, encodedContent);
                    break;
                case HttpVerbs.Delete:
                    result = client.DeleteAsync(MyUri);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
