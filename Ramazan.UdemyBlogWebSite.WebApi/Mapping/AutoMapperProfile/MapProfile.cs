using AutoMapper;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.BlogDtos;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryDtos;
using Ramazan.UdemyBlogWebSite.Entities.Concreate;
using Ramazan.UdemyBlogWebSite.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile() //kimle kim maplenicek onu belirtiyorum
        {
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog , BlogListDto>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto,Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
