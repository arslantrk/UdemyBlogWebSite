using FluentValidation;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("parola alanı boş geçilemez");
        }
    }
}
