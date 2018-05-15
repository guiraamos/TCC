namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("http://localhost:1479/api/")]
    public interface IMsAuthenticateControllerService
    {
        [MicroService("Authenticate")]
        IRestResponse MsAuthenticate(List<KeyValuePair<object, object>> parameters = null);
    }
}