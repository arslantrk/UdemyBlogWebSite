using Microsoft.EntityFrameworkCore;
using Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Context;
using Ramazan.UdemyBlogWebSite.DataAccess.Interfaces;
using Ramazan.UdemyBlogWebSite.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Blogs.Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, CategoryBlog) => new
            {
                blog = blog,
                categoryBlog = CategoryBlog
            }).Where(I => I.categoryBlog.CategoryId == categoryId).Select(I => new Blog {
                AppUser = I.blog.AppUser,
                AppUserId = I.blog.AppUserId,
                CategoryBlogs = I.blog.CategoryBlogs,
                Comments = I.blog.Comments,
                Description = I.blog.Description,
                Id = I.blog.Id,
                ImagePath = I.blog.ImagePath,
                PostedTime = I.blog.PostedTime,
                ShortDescription = I.blog.ShortDescription,
                Title = I.blog.Title
            }).ToListAsync();
        }
    }
}
