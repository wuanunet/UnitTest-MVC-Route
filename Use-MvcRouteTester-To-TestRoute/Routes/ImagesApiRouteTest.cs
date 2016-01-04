using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Sample.WebAPI;
using Sample.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace Use_MvcRouteTester_To_TestRoute.Routes
{
    [TestClass]
    public class ImagesApiRouteTest
    {
        private HttpConfiguration testConfig;

        public ImagesApiRouteTest()
        {
            //// Arrange
            testConfig = new HttpConfiguration();
            WebApiConfig.Register(testConfig);
            testConfig.EnsureInitialized();
        }

        /// <summary>
        /// api/Images/Original/type/1 測試
        /// </summary>
        [TestMethod]
        public void ImagesRoute_RouteWith_Controller_Index_Action_Type_Id_ShouldMapToRenderOriginal()
        {
            testConfig.ShouldMap("/api/Images/Original/type/1")
                      .To<ImagesController>(c => c.RenderOriginal(string.Empty, string.Empty));

            testConfig.ShouldMap("/api/Images/Original/type/1")
                      .To<ImagesController>(HttpMethod.Get, c => c.RenderOriginal(string.Empty, string.Empty));

            testConfig.ShouldMap("/api/Images/Original/type/1")
                      .To<ImagesController>(HttpMethod.Post, c => c.RenderOriginal(string.Empty, string.Empty));
        }
    }
}