using System.Collections.Generic;
using MicroServiceNet;
using RestSharp;

namespace WebApplication1.Service
{
    [MicroServiceHost("MsProduct")]
    public interface IProductService : IMicroServiceNet
    {
        [MicroService("GetAllProducts")]
        IRestResponse GetAllProducts(List<KeyValuePair<object, object>> parameters = null);


        [MicroService("AddProduct")]
        IRestResponse AddProduct(List<KeyValuePair<object, object>> parameters = null);
    }
}