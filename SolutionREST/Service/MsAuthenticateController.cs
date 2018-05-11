namespace Service
{
    using System.Collections.Generic;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("http://localhost:1479/api/")]
    public interface IMsAuthenticateControllerService : IMicroServiceBase
    {
        [MicroService("Authenticate")]
        IRestResponse MsAuthenticate(List<KeyValuePair<object, object>> parameters = null);
    }
}