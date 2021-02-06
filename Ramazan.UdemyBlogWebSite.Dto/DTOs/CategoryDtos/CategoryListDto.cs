using Ramazan.UdemyBlogWebSite.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryDtos
{
    public class CategoryListDto :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
