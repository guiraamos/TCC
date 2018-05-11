namespace Service
{
    using System.Collections.Generic;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("http://localhost:1479/api/Newsletter/")]
    public interface MsNewsletterController : IMicroServiceBase
    {
        [MicroService("Subscribe")]
        IRestResponse Subscribe(List<KeyValuePair<object, object>> parameters = null);
        [MicroService("Publish")]
        IRestResponse Publish(List<KeyValuePair<object, object>> parameters = null);
    }
}