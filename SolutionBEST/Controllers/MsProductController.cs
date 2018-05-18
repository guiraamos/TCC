using MicroServiceNet;
using Service;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace SolutionBEST.Controllers
{
    public class MsProductController : MicroServiceController<MsProductController>
    {
        [Import(typeof(IMsProductControllerService))]
        IMsProductControllerService _productService;

        public ActionResult GetAll()
        {
            var request = _productService.GetAll();
            var r = request.Result;

            return View();
        }
    }
}