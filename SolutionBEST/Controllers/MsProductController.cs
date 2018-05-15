using MicroServiceNet;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using WebApplication1.Service;

namespace SolutionBEST.Controllers
{
    public class MsProductController : MicroServiceController<MsProductController>
    {
        [Import(typeof(IProductService))]
        IProductService _productService;

        public ActionResult GetAll()
        {
            var request = _productService.GetAllProducts();
            var r = request.Content;

            return View();
        }
    }
}