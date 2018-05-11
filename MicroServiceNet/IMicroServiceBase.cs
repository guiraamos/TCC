using RestSharp;
using System;
using System.Collections.Generic;

namespace MicroServiceNet
{
    public interface IMicroServiceBase
    {
        IRestResponse Execute<T>(Func<List<KeyValuePair<object, object>>, IRestResponse> method, Method methodHttp, List<KeyValuePair<object, object>> parameters = null) where T : IMicroServiceBase;
    }
}
