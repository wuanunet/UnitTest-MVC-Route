using Sample.MVC.Models;
using System;
using System.Web.Mvc;

namespace Sample.MVC.Controllers
{
    [RoutePrefix("AllArticles")]
    public class ArticlesController : Controller
    {
        [Route("{id}")]
        public ActionResult Index(string id)
        {
            var result = new ArticleDataViewModel
            {
                Title = "Article Test From MVC",
                Content = "Good Article",
                CreateAt = DateTime.UtcNow
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}