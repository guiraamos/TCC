using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MicroServiceNet;

namespace SolutionBEST2.Services
{
    [MicroServiceHost("http://localhost:26709/api/Product/")]
    public interface IMsProductControllerService
    {
        [MicroService("GetAllProducts", HttpRequestBase)]
        Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null);
    }
}