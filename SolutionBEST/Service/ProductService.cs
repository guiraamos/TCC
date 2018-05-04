using System.Collections.Generic;
using MicroServiceNet;
using RestSharp;

namespace WebApplication1.Service
{
    [MicroServiceHost("http://localhost:26709/api")]
    public class ProductService : MicroServiceBase
    {
        [MicroService("GetAllProducts")]
        public static IRestResponse GetAllProducts(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(GetAllProducts, Method.POST, parameters);
        }

        [MicroService("AddProduct")]
        public static IRestResponse AddProduct(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(AddProduct, Method.POST, parameters);
        }
    }
}