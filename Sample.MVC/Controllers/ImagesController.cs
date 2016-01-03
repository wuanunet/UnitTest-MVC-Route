using Sample.MVC.Models;
using System;
using System.Web.Mvc;

namespace Sample.MVC.Controllers
{
    public class ImagesController : Controller
    {
        [HttpGet]
        public ActionResult RenderOriginal(string type, string id)
        {
            var result = new ImageDataViewModel
            {
                FileName = "TestFromMVC",
                LastModifiedTime = DateTime.UtcNow
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}