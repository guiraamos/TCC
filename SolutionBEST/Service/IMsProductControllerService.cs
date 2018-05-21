namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using MicroServiceNet;

    [MicroServiceHost("http://localhost:26709/api/Product/")]
    public interface IMsProductControllerService
    {
        [MicroService("GetAllProducts", HttpMethod.Post)]
        Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null);
    }
}