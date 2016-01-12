using Sample.WebAPI.Models;
using System;
using System.Web.Http;

namespace Sample.WebAPI.Controllers
{
    [RoutePrefix("API/Articles")]
    public class ArticlesController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public ArticleDataViewModel Get(string id)
        {
            var result = new ArticleDataViewModel
            {
                Title = "Article Test From API",
                Content = "Good Article",
                CreateAt = DateTime.UtcNow
            };

            return result;
        }
    }
}