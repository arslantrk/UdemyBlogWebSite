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
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Categories.OrderByDescending(I=>I.Id).Include(I => I.CategoryBlogs).ToListAsync();
        }
    }
}
