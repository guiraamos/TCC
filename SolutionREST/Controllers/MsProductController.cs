using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SolutionREST.Controllers
{
    public class MsProductController : Controller
    {

        public async Task<IActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                var tokenServiceResponse = await client.GetAsync("http://localhost:26709/api/Product/GetAllProducts");
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }
    }
}