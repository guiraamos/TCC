namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [Export(typeof(IMsNewsletterControllerService))]
    [MicroServiceHost("http://localhost:1479/api/Newsletter/")]
    public class MsNewsletterController : MicroServiceBase, IMsNewsletterControllerService
    {
        [MicroService("Subscribe")]
        public IRestResponse Subscribe(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsNewsletterController>(Subscribe, Method.POST, parameters);
        }

        [MicroService("Publish")]
        public IRestResponse Publish(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsNewsletterController>(Publish, Method.POST, parameters);
        }
    }
}