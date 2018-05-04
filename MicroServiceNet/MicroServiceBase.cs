using System;
using System.Collections.Generic;
using RestSharp;

namespace MicroServiceNet
{
    public class MicroServiceBase
    {
        public static IRestResponse Execute<T>(Func<List<KeyValuePair<object, object>>, IRestResponse> method, Method methodHttp, List<KeyValuePair<object, object>> parameters = null) where T : MicroServiceBase
        {
            var request = new RestRequest(MicroServiceAttribute.GetMicroService(method), methodHttp);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key.ToString(), parameter.Value);
                }
            }

            return new RestClient(MicroServiceHostAttribute.GetMicroService(method)).Execute(request);
        }
    }
}
