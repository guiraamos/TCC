using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsSale.Services;
using System;

namespace MsSale.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {

        public string Executa(HttpRequest req, HttpResponse res)
        {
            string user = req.Query["username"].ToString();
            string password = req.Query["password"].ToString();
            try
            {
                if (Services.Services.ServiceAuthentication(user, password))
                {
                    return "sale.jsp";
                }
                else
                {
                    req.QueryString.Add("login_fail", "true");
                    return "index.jsp";
                }
            }
            catch (Exception ex)
            {
                req.QueryString.Add("server_not_available", "Authentication server not available (" + ex.GetType().ToString() + ": " + ex.Message + ")");
                return "index.jsp";
            }
        }
    }
}
        