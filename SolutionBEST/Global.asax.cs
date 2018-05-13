using MicroServiceNet;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            teste();
        }

        private void teste()
        {
            var a = Assembly.GetExecutingAssembly();
            foreach(var interfacee in a.GetExportedTypes().Where(t => t.IsInterface))
            {

            }
        }
    }
}
