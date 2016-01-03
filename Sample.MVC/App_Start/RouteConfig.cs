using System.Web.Mvc;
using System.Web.Routing;

namespace Sample.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //// Images 相關
            MapImages(routes);

            //// Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults:
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        private static void MapImages(RouteCollection routes)
        {
            routes.MapRoute(
                name: "RenderOriginal",
                url: "Images/Original/{type}/{id}/{version}",
                defaults:
                new
                {
                    controller = "Images",
                    action = "RenderOriginal",
                    id = UrlParameter.Optional,
                    version = "0"
                }
            );
        }
    }
}