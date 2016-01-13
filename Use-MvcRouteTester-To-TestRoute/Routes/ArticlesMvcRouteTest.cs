using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Sample.MVC;
using Sample.MVC.Controllers;
using System;
using System.Net.Http;
using System.Web.Routing;

namespace Use_MvcRouteTester_To_TestRoute.Routes
{
    [TestClass]
    public class ArticlesMvcRouteTest : IDisposable
    {
        private RouteCollection testRoutes;

        public ArticlesMvcRouteTest()
        {
            //// Arrange
            testRoutes = new RouteCollection();
            testRoutes.MapAttributeRoutesInAssembly(typeof(ArticlesController));
            RouteConfig.RegisterRoutes(testRoutes);
        }

        public void Dispose()
        {
            testRoutes.Clear();
        }

        [TestMethod]
        public void ArticlesRoute_WithHttpMethod_Get_RouteWith_Controller_Get_Action_Id_ShouldMap()
        {
            testRoutes.ShouldMap("/AllArticles/1")
                      .To<ArticlesController>(c => c.Index(string.Empty));

            testRoutes.ShouldMap("/AllArticles/1")
                      .To<ArticlesController>(HttpMethod.Get, c => c.Index(string.Empty));
        }
    }
}