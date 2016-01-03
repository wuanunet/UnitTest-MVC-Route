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
    public class ImagesMvcRouteTest : IDisposable
    {
        private RouteCollection testRoutes;

        public ImagesMvcRouteTest()
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
        public void ImagesRoute_RouteWith_Controller_Index_Action_Type_Id_ShouldMapToRenderOriginal()
        {
            testRoutes.ShouldMap("/Images/Original/type/1")
                      .To<ImagesController>(c => c.RenderOriginal(string.Empty, string.Empty));

            testRoutes.ShouldMap("/Images/Original/type/1")
                      .To<ImagesController>(HttpMethod.Get, c => c.RenderOriginal(string.Empty, string.Empty));

            testRoutes.ShouldMap("/Images/Original/type/1")
                      .To<ImagesController>(HttpMethod.Post, c => c.RenderOriginal(string.Empty, string.Empty));
        }
    }
}