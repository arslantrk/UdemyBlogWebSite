using Ramazan.UdemyBlogWebSite.Business.Interfaces;
using Ramazan.UdemyBlogWebSite.DataAccess.Interfaces;
using Ramazan.UdemyBlogWebSite.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.Business.Concrete
{
    public class BlogManager : GenericManager<Blog> , IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsnync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);//yayınlanma tarihine göre sıralanıp getirilicek
        }
    }
}
