using System.Web.Http;

namespace Sample.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //// Images 相關
            MapImages(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void MapImages(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "RenderOriginal",
                routeTemplate: "api/Images/Original/{type}/{id}/{version}",
                defaults:
                new
                {
                    controller = "Images",
                    action = "RenderOriginal",
                    id = RouteParameter.Optional,
                    version = "0"
                }
            );
        }
    }
}