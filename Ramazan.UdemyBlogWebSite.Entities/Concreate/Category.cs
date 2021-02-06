using Ramazan.UdemyBlogWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Entities.Concreate
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
