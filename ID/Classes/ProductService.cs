using System.Collections.Generic;
using MicroServiceNet;
using RestSharp;

namespace MicroServiceNet.Classes
{
    public class ProductService : MicroServiceBase, WebApplication1.Service.IProductService
    {
        public IRestResponse AddProduct(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(GetAllProducts, Method.POST, parameters);
        }

        public IRestResponse GetAllProducts(List<KeyValuePair<object, object>> parameters = null)
        {
            return Execute<ProductService>(AddProduct, Method.POST, parameters);
        }
    }
}