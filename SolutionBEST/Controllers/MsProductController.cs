using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace SolutionBEST.Controllers
{
    public class MsProductController : Controller
    {
        public async Task<IActionResult> Add()
        {

            var parameters = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("name", "Elena"),
                new KeyValuePair<object, object>("description", "description teste"),
                new KeyValuePair<object, object>("number", 1),
                new KeyValuePair<object, object>("value", 200)
            };

            ProductService.AddProduct(parameters);

            return View();
        }
    }


    public async Task<IActionResult> GetAll()
    {
        var request = ProductService.GetAllProducts();
        var r = request.Content;

        return View();
    }
}
    }
}