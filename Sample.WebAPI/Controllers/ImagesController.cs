using Sample.WebAPI.Models;
using System;
using System.Web.Http;

namespace Sample.WebAPI.Controllers
{
    public class ImagesController : ApiController
    {
        [HttpGet]
        public ImageDataViewModel RenderOriginal(string type, string id)
        {
            var result = new ImageDataViewModel
            {
                FileName = "TestFromAPI",
                LastModifiedTime = DateTime.UtcNow
            };

            return result;
        }
    }
}