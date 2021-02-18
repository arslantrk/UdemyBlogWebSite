using FluentValidation;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id alanı boş geçilemez");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
