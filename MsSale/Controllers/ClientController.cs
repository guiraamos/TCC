using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MsSale.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        public string Executa(HttpRequest req, HttpResponse res)
        {
            string clientJson;
            try
            {
                string cpf = req.Query["cpf"].ToString();
                clientJson = Services.Services.ServiceGetClient(cpf);
            }
            catch (Exception ex)
            {
                req.QueryString.Add("server_not_available", "Client server not available (" + ex.GetType().ToString() + ": " + ex.Message + ")");
                return "sale.jsp";
            }

            string productsJson = "[]";
            try
            {
                productsJson = Services.Services.ServiceGetProducts();
            }
            catch (Exception ex)
            {
                req.QueryString.Add("server_not_available", "Product server not available (" + ex.GetType().ToString() + ": " + ex.Message + ")");
                return "sale.jsp";
            }

            req.QueryString.Add("jsonProducts", productsJson);
            req.QueryString.Add("client", clientJson);
            req.QueryString.Add("client_search", "true");

            return "sale.jsp";
        }

    }
}