using System.Web.Mvc;
using System.Web.Routing;

namespace BridalBoutique
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "adminProduct",
                url: "admin/products/{id}",
                defaults: new { controller = "products", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "adminCategories",
               url: "admin/categories/{id}",
               defaults: new { controller = "categories", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
