namespace Service
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using MicroServiceNet;

    [Export(typeof(IMsProductControllerService))]
    [MicroServiceHost("http://localhost:26709/api/Product/")]
    public class MsProductController : MicroServiceBase, IMsProductControllerService
    {
        [MicroService("GetAllProducts")]
        public Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute<MsProductController>(GetAll, HttpVerbs.Get, parameters);
        }
    }
}