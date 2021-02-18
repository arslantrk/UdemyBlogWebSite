using FluentValidation;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryBlogDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(I => I.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("CategoryId boş geçilemez");
            RuleFor(I => I.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("BlogId boş geçilemez");
        }
    }
}
