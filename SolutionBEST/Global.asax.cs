using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MicroServiceNet;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {

            var container = new Container();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Dependencias.RegistrarDependencias();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SimpleInjectorContainer.RegisterServices(container)));
        }

        
    }
}
