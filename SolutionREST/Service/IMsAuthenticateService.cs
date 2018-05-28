namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("MSAUTHENTICATE")]
    public interface IMsAuthenticateService : IMicroService
    {
        [MicroService("Authenticate", TypeRequest.Post)]
        Task<HttpResponseMessage> MsAuthenticate(List<KeyValuePair<string, string>> parameters = null);
    }
}