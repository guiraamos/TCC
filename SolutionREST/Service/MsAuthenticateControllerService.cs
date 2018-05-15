namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [Export(typeof(IMsAuthenticateControllerService))]
    [MicroServiceHost("http://localhost:1479/api/")]
    public class MsAuthenticateController : MicroServiceBase, IMsAuthenticateControllerService
    {
        [MicroService("Authenticate")]
        public IRestResponse MsAuthenticate(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsAuthenticateController>(MsAuthenticate, Method.POST, parameters);
        }
    }
}