# UnitTest-MVC-Route

## 專案結構說明

* Sample.MVC：ASP.NET MVC 5
* Sample.WebAPI：ASP.NET WebAPI 2
* Use-MvcRouteTester-To-TestRoute：使用 **MvcRouteTester** 套件
* Use-MvcRouteUnitTester-To-TestRoute：使用 **MvcRouteUnitTester** 套件


## 1. Use-MvcRouteUnitTester-To-TestRoute Project

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


## 2. Use-MvcRouteTester-To-TestRoute Project

這是使用 **MvcRouteTester** 套件，來做 ASP.NET MVC Route 測試的範例專案






## Commit Logs

### 2016-01-03
* BTS001 調整Images/Original的回傳資料型別。
* BTS001 修正View-WebConfig命名空間。
* BTS001 調整Use_MvcRouteUnitTester_To_TestRoute測試專案的RouteConfigTest名稱。

### 2016-01-04
* BTS002 - Add Project. 1.Sample.WebAPI. 2.Use-MvcRouteTester-To-TestRoute.
* BTS002 - Clean Code.

### 2016-01-05
* BTS003 - 修正ImagesMvcRouteTest與ImagesApiRouteTest命名的錯誤。



----------


以上。

若有不清楚或是需要進一步協助請再讓我知道。謝謝。
