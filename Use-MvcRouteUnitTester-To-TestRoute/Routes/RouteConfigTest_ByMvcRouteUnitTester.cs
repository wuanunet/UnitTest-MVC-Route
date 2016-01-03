using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteUnitTester;
using Sample.MVC;
using System.Web.Routing;

namespace Use_MvcRouteUnitTester_To_TestRoute.Routes
{
    [TestClass]
    public class RouteConfigTest_ByMvcRouteUnitTester
    {
        [TestMethod]
        public void DefaultRouteTest()
        {
            //// Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var routeTester = new RouteTester(routes);

            //// Assert
            routeTester.WithIncomingRequest("/").ShouldMatchRoute("Home", "Index");
            routeTester.WithIncomingRequest("/Home").ShouldMatchRoute("Home", "Index");
            routeTester.WithIncomingRequest("/Home/Index").ShouldMatchRoute("Home", "Index");
        }

        [TestMethod]
        public void HomeIndex_RouteTest_Should_MatchRoute()
        {
            //// Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var expectedControllerName = "Home";
            var expectedActionName = "Index";

            var routeTester = new RouteTester(routes);

            //// Act
            var requsetInfo = routeTester.WithIncomingRequest("/");

            //// Assert
            requsetInfo.ShouldMatchRoute(expectedControllerName, expectedActionName);
        }

        [TestMethod]
        public void Home_RouteTest_Should_MatchRoute()
        {
            //// Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var expectedControllerName = "Home";
            var expectedActionName = "Index";

            var routeTester = new RouteTester(routes);

            //// Act
            var requsetInfo = routeTester.WithIncomingRequest("/Home");

            //// Assert
            requsetInfo.ShouldMatchRoute(expectedControllerName, expectedActionName);
        }

        [TestMethod]
        public void HomeTest1Test_RouteTest_Should_Not_MatchRoute()
        {
            //// Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var routeTester = new RouteTester(routes);

            //// Act
            var requsetInfo = routeTester.WithIncomingRequest("/Home/Test/1/Test");

            //// Assert
            requsetInfo.ShouldMatchNoRoute();
        }
    }
}