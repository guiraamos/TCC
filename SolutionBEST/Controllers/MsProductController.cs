using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Service;

namespace SolutionBEST.Controllers
{
    public class MsProductController : Controller
    {
        IProductService _productService;

        public MsProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult GetAll()
        {
            var request = _productService.GetAllProducts();
            var r = request.Content;

            return View();
        }
    }
}