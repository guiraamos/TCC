namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [Export(typeof(IMsProductControllerService))]
    [MicroServiceHost("http://localhost:26709/api/Product/")]
    public class MsProductController : MicroServiceBase, IMsProductControllerService
    {
        [MicroService("GetAllProducts")]
        public IRestResponse GetAll(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<MsProductController>(GetAll, Method.GET, parameters);
        }
    }
}