﻿using Sample.MVC.Models;
using System;
using System.Web.Mvc;

namespace Sample.MVC.Controllers
{
    public class ImagesController : Controller
    {
        public ImageDataViewModel RenderOriginal(string type, string id)
        {
            var result = new ImageDataViewModel
            {
                FileName = "Test",
                LastModifiedTime = DateTime.UtcNow
            };

            return result;
        }
    }
}