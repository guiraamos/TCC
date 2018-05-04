using MicroServiceNet;
using RestSharp;
using System.Web.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ExemploConsumoRestSharp()
        {
            var request = new RestRequest(MicroServiceAttribute.GetMicroService(ProductService.GetAllProducts),Method.POST);

            request.AddParameter("username", "guilherme");
            request.AddParameter("password", "senha123");

            var response = new RestClient(MicroServiceHostAttribute.GetMicroService(ProductService.GetAllProducts)).Execute(request);

            return View();
        }
    }
}