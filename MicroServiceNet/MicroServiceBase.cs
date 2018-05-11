using RestSharp;
using System;
using System.Collections.Generic;

namespace MicroServiceNet
{
    public class MicroServiceBase : IMicroServiceBase
    {
        public IRestResponse Execute<T>(Func<List<KeyValuePair<object, object>>, IRestResponse> method, Method methodHttp, List<KeyValuePair<object, object>> parameters = null) 
            where T : IMicroServiceBase
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
