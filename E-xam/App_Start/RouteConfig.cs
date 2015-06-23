
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_xam
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default", url: "{controller}/{action}/{id}",
                namespaces: new[] { "E_xam.MVCWebUI.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            
        }
    }
}
