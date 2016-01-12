using System;

namespace Sample.WebAPI.Models
{
    public class ArticleDataViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateAt { get; set; }
    }
}