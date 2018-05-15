namespace Service
{
    using System.Collections.Generic;
    using System.Composition;
    using MicroServiceNet;
    using RestSharp;

    [MicroServiceHost("http://localhost:26709/api/Product/")]
    public interface IMsProductControllerService : IMicroServiceBase
    {
        [MicroService("GetAllProducts")]
        IRestResponse GetAll(List<KeyValuePair<object, object>> parameters = null);
    }
}