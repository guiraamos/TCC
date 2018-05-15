namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("http://localhost:1479/api/Newsletter/")]
    public interface IMsNewsletterControllerService : IMicroServiceBase
    {
        [MicroService("Subscribe")]
        IRestResponse Subscribe(List<KeyValuePair<object, object>> parameters = null);
        [MicroService("Publish")]
        IRestResponse Publish(List<KeyValuePair<object, object>> parameters = null);
    }
}