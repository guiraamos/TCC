using MicroServiceNet;

namespace WebApplication1.Service
{
    [MicroServiceHost("http://localhost:1479/api/")]
    public class ProductService
    {
        [MicroService("Authenticate")]
        public static string GetAllProducts(){ return ""; }
    }
}