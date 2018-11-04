using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dido_Store_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Branch",
                url: "san-pham/{Alias}-{branchID}",
                defaults: new { controller = "Product", action = "ProductBranch", id = UrlParameter.Optional },
                namespaces: new[] { "Dido_Store_2.Controllers" }
            );


            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{Alias}-{productID}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dido_Store_2.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dido_Store_2.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dido_Store_2.Controllers" }
            );
        }
    }
}
