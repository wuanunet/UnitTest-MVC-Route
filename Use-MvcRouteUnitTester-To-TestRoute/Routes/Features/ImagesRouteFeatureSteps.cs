using MvcRouteUnitTester;
using Sample.MVC;
using System.Web.Routing;
using TechTalk.SpecFlow;

namespace Use_MvcRouteUnitTester_To_TestRoute.Routes
{
    [Binding]
    [Scope(Feature = "ImagesRouteFeature")]
    public class ImagesRouteFeatureSteps
    {
        /// <summary>
        /// ActionName
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// ActionParameter
        /// </summary>
        public object ActionParameter { get; set; }

        /// <summary>
        /// ApiMethod
        /// </summary>
        public string ApiMethod { get; set; }

        /// <summary>
        /// ControllerName
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// RouteTester
        /// </summary>
        public RouteTester RouteTester { get; set; }

        /// <summary>
        /// RequestInfo
        /// </summary>
        public RequestInfo RequestInfo { get; set; }

        /// <summary>
        /// 運行測試前
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            this.RouteTester = new RouteTester(routes);
        }

        /// <summary>
        /// 設定ApiMethod
        /// </summary>
        /// <param name="method">method</param>
        [Given(@"外部呼叫的網址為 ""(.*)""")]
        public void Given外部呼叫的網址為(string method)
        {
            this.ApiMethod = method;
        }

        [When(@"在進入網站，經過路由配對流程之後")]
        public void When在進入網站經過路由配對流程之後()
        {
            this.RequestInfo = this.RouteTester.WithIncomingRequest(this.ApiMethod);
        }

        [Then(@"配對結果，預期符合Controller為 ""(.*)""，Action為 ""(.*)""，以及類別、序號、版本參數設定")]
        public void Then配對結果預期符合Controller為Action為以及類別序號版本參數設定(string controllerName, string actionName)
        {
            this.ControllerName = controllerName;
            this.ActionName = actionName;
            this.ActionParameter = new
            {
                type = "type",
                id = "id",
                version = "version"
            };
        }

        [Then(@"且這個比對結果是存在又正確的路由")]
        public void Then且這個比對結果是存在又正確的路由()
        {
            this.RequestInfo.ShouldMatchRoute(this.ControllerName, this.ActionName, this.ActionParameter);
        }
    }
}