# UnitTest-MVC-Route

這是使用 **MvcRouteUnitTester** 套件，來做 ASP.NET MVC Route 測試的範例專案

    [TestMethod]
    public void DefaultRoute_RouteTest()
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

這專案的說明文：[ASP.NET MVC Route Unit Test - Part.1](https://dotblogs.com.tw/wuanunet/2015/12/26/aspnet-mvc-route-unit-test-part1)

以上。

若有不清楚或是需要進一步協助請再讓我知道。謝謝。
