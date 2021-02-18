using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Ramazan.UdemyBlogWebSite.Business.Concrete;
using Ramazan.UdemyBlogWebSite.Business.Interfaces;
using Ramazan.UdemyBlogWebSite.Business.ToolsUtilities.JWTTool;
using Ramazan.UdemyBlogWebSite.Business.ValidationRules.FluentValidation;
using Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Repositories;
using Ramazan.UdemyBlogWebSite.DataAccess.Interfaces;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.AppUserDtos;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryBlogDtos;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryDtos;
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
            services.AddScoped<IBlogDal, EfBlogRepository>();//IblogDalı gördüğünde EfBlogRepo... örnekle4

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            //JWT
            services.AddScoped<IJwtService, JwtManager>();

            //FluentValidator//Transient Kullandım çünkü her seferinde yeni bir örnek alınmasını istiyorum.
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            //newtonsofta AddFuluentValidation ekledim.
        }
    }
}