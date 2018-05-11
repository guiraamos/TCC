using System.Collections.Generic;
using MicroServiceNet;
using RestSharp;

namespace WebApplication1.Service
{
    [MicroServiceHost("http://localhost:26709/api")]
    public class ProductService : MicroServiceBase, IProductService
    {
        [MicroService("GetAllProducts")]
        public IRestResponse AddProduct(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(GetAllProducts, Method.POST, parameters);
        }


        [MicroService("AddProduct")]
        public IRestResponse GetAllProducts(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(AddProduct, Method.POST, parameters);
        }
    }
}