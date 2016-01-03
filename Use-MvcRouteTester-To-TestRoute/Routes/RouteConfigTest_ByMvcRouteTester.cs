using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Sample.MVC;
using Sample.MVC.Controllers;
using System;
using System.Web.Routing;

namespace Use_MvcRouteTester_To_TestRoute.Routes
{
    [TestClass]
    public class RouteConfigTest_ByMvcRouteTester : IDisposable
    {
        private RouteCollection testRoutes;

        public RouteConfigTest_ByMvcRouteTester()
        {
            //// Arrange
            testRoutes = new RouteCollection();
            RouteConfig.RegisterRoutes(testRoutes);
        }

        public void Dispose()
        {
            testRoutes.Clear();
        }

        [TestMethod]
        public void DefaultRouteTest()
        {
            //// Assert
            RouteAssert.HasRoute(testRoutes, "/", "Home", "Index");
            RouteAssert.HasRoute(testRoutes, "/Home", "Home", "Index");
            RouteAssert.HasRoute(testRoutes, "/Home/Index", "Home", "Index");
        }

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
    }
}