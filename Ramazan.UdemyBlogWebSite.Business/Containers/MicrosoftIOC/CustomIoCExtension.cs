using Microsoft.Extensions.DependencyInjection;
using Ramazan.UdemyBlogWebSite.Business.Concrete;
using Ramazan.UdemyBlogWebSite.Business.Interfaces;
using Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Repositories;
using Ramazan.UdemyBlogWebSite.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.Containers.MicrosoftIOC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {//bağımlılıklarımızı belirtiyoruz
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();//IblogDalı gördüğünde EfBlogRepo... örnekle

        }
    }
}
