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

#### 專案說明文：
* [ASP.NET MVC Route Unit Test - Part.1](https://dotblogs.com.tw/wuanunet/2015/12/26/aspnet-mvc-route-unit-test-part1)


## 2. Use-MvcRouteTester-To-TestRoute Project

這是使用 **MvcRouteTester** 套件，來做 ASP.NET MVC Route 測試的範例專案

### MVC 5 Project

	var routes = new RouteCollection();
	routes.MapRoute(
	    name: "Default",
	    url: "{controller}/{action}/{id}",
	    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

	//// 驗證/home/index是否符合規則
	RouteAssert.HasRoute(routes, "/home/index");
	
	//// 驗證/home/Index/42是否符合規則
	var expectedRoute = new { controller = "Home", action = "Index", id = 42 };
	RouteAssert.HasRoute(routes, "/home/Index/42", expectedRoute);

or

	/// <summary>
    /// 預設路由 - 根目錄測試 (無指定Controller、Index、Id)
    /// </summary>
    [TestMethod]
    public void DefaultRoute_RootWithNoControllerNoActionNoId_ShouldMapToIndex()
    {
    	testRoutes.ShouldMap("/").To<HomeController>(c => c.Index());
    }
    
    /// <summary>
    /// Home 測試 (無指定Index、Id)
    /// </summary>
    [TestMethod]
    public void Home_RouteWithControllerNoActionNoId_ShouldMapToIndex()
    {
    	testRoutes.ShouldMap("/Home").To<HomeController>(c => c.Index());
    }
    
    /// <summary>
    /// Home/Index 測試 (無指定Id)
    /// </summary>
    [TestMethod]
    public void HomeIndex_RouteWithControllerIndexActionNoId_ShouldMapToIndex()
    {
    	testRoutes.ShouldMap("/Home/Index").To<HomeController>(c => c.Index());
    }


### WebAPI 2 Project

	var apiRoutesConfig = new HttpConfiguration();
	apiRoutesConfig .Routes.MapHttpRoute(
	    name: "DefaultApi",
	    routeTemplate: "api/{controller}/{id}",
	    defaults: new { id = RouteParameter.Optional }
	);

	//// 驗證/api/customer/1是否符合規則
	RouteAssert.HasApiRoute(apiRoutesConfig , "/api/customer/1", HttpMethod.Get);
	
	//// 驗證/api/customer/1是否符合規則
	var expectation = new { controller = "Customer", action= "get", id = "1" };
	RouteAssert.HasApiRoute(apiRoutesConfig , "/api/customer/1", HttpMethod.Get, expectation);

or

	/// <summary>
	/// 使用 HttpMethod Get 進行 api/Images/Original/type/1 測試
	/// </summary>
	[TestMethod]
	public void ImagesRoute_WithHttpMethod_Get_RouteWith_Controller_Index_Action_Type_Id_ShouldMapToRenderOriginal()
	{
		testConfig.ShouldMap("/api/Images/Original/type/1")
		  .To<ImagesController>(c => c.RenderOriginal(string.Empty, string.Empty));
		
		testConfig.ShouldMap("/api/Images/Original/type/1")
		  .To<ImagesController>(HttpMethod.Get, c => c.RenderOriginal(string.Empty, string.Empty));
	}
	
	/// <summary>
	/// 預期 沒有 HttpMethod Post 方法，可以呼叫到 api/Images/Original/type/1 測試
	/// </summary>
	[TestMethod]
	public void ImagesRoute_NoHttpMethod_Post_RouteWith_Controller_Index_Action_Type_Id_ShouldMapToRenderOriginal()
	{
		testConfig.ShouldMap("/api/Images/Original/type/1")
		  .ToNoMethod<ImagesController>(HttpMethod.Post);
	}


#### 專案說明文：
* [ASP.NET MVC Route Unit Test - Part.2 - MvcRouteTester - MVC Project](https://dotblogs.com.tw/wuanunet/2016/01/03/aspnet-mvc-route-unit-test-part2-with-mvcroutetester-library-for-mvc-project)
* [ASP.NET MVC Route Unit Test - Part.3 - MvcRouteTester - WebAPI Project](https://dotblogs.com.tw/wuanunet/2016/01/05/aspnet-mvc-route-unit-test-part3-with-mvcroutetester-library-for-webapi-project)
* [ASP.NET MVC Route Unit Test - Part.4 - MvcRouteTester - Attribute Routing](https://dotblogs.com.tw/wuanunet/2016/01/05/aspnet-mvc-route-unit-test-part4-with-mvcroutetester-library-for-attribute-routing)

## Commit Logs

#### 2016-01-03
* BTS001 調整Images/Original的回傳資料型別。
* BTS001 修正View-WebConfig命名空間。
* BTS001 調整Use_MvcRouteUnitTester_To_TestRoute測試專案的RouteConfigTest名稱。

#### 2016-01-04
* BTS002 - Add Project. 1.Sample.WebAPI. 2.Use-MvcRouteTester-To-TestRoute.
* BTS002 - Clean Code.

#### 2016-01-05
* BTS003 - 修正ImagesMvcRouteTest與ImagesApiRouteTest命名的錯誤。

#### 2016-01-06
* BTS004 - 調整 WebAPI - ImagesController，HttpGet與HttpPost的測試案例。

#### 2016-01-12
* BTS005 - WebAPI - 新增ArticlesController等相關程式。
* BTS005 - 新增ArticlesApiRoute測試程式。

#### 2016-01-14
* BTS006 - MVC - 1.新增ArticlesController等相關程式。2.設定 Attribute Routing。
* BTS006 - 新增ArticlesMvcRoute測試程式。
* BTS006 - 修改ArticlesApiRoute測試案例描述，移除Type字樣。

----------


以上。

若有不清楚或是需要進一步協助請再讓我知道。謝謝。
