using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Sample.WebAPI;
using Sample.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace Use_MvcRouteTester_To_TestRoute.Routes
{
    /// <summary>
    /// ArticlesApiRouteTest
    /// </summary>
    [TestClass]
    public class ArticlesApiRouteTest
    {
        /// <summary>
        /// HttpConfiguration
        /// </summary>
        private HttpConfiguration testConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesApiRouteTest"/> class.
        /// </summary>
        public ArticlesApiRouteTest()
        {
            //// Arrange
            testConfig = new HttpConfiguration();
            WebApiConfig.Register(testConfig);
            testConfig.EnsureInitialized();
        }

        /// <summary>
        /// 使用 HttpMethod Get 進行 /api/Articles/1 測試
        /// </summary>
        [TestMethod]
        public void ArticlesRoute_WithHttpMethod_Get_RouteWith_Controller_Get_Action_Id_ShouldMap()
        {
            testConfig.ShouldMap("/api/Articles/1")
                      .To<ArticlesController>(c => c.Get(string.Empty));

            testConfig.ShouldMap("/api/Articles/1")
                      .To<ArticlesController>(HttpMethod.Get, c => c.Get(string.Empty));
        }
    }
}