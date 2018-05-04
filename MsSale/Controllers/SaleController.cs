using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MsSale.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller, ILogic
    {
        [HttpPost, Route("Executa")]
        public string Executa(HttpRequest req, HttpResponse res)
        {
            string[] ids = req.Query["product_id"];
            string[] qtds = req.Query["product_qtd"];

            if (ids != null && qtds != null && ids.Length > 0 && qtds.Length > 0 && ids.Length == qtds.Length)
            {
                try
                {
                    bool success = Services.Services.ServiceUpdateStock(ids, qtds);
                    req.QueryString.Add("sale_submitted", "true");
                    req.QueryString.Add("success", success.ToString());
                }
                catch (Exception ex)
                {
                    req.QueryString.Add("server_not_available", "Product server not available (" + ex.GetType().ToString() + ": " + ex.Message + ")");
                }
            }
            else
            {
                req.QueryString.Add("sale_submitted", "true");
                req.QueryString.Add("success", "false");
            }

            return "sale.jsp";
        }
    }
}