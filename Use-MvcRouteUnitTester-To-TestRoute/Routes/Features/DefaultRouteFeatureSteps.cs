using MvcRouteUnitTester;
using Sample.MVC;
using System.Web.Routing;
using TechTalk.SpecFlow;

namespace Use_MvcRouteUnitTester_To_TestRoute.Routes
{
    [Binding]
    [Scope(Feature = "DefaultRouteFeature")]
    public class DefaultRouteFeatureSteps
    {
        /// <summary>
        /// ActionName
        /// </summary>
        public string ActionName { get; set; }

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

        [Then(@"配對結果，預期符合Controller為 ""(.*)""，Action為 ""(.*)""")]
        public void Then配對結果預期符合Controller為Action為(string controllerName, string actionName)
        {
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        [Then(@"且這個比對結果是存在又正確的路由")]
        public void Then且這個比對結果是存在又正確的路由()
        {
            this.RequestInfo.ShouldMatchRoute(this.ControllerName, this.ActionName);
        }

        [Then(@"配對結果，預期是一個不存在的路由")]
        public void Then配對結果預期是一個不存在的路由()
        {
            this.RequestInfo.ShouldMatchNoRoute();
        }
    }
}