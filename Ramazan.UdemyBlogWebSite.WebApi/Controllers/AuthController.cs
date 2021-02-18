using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ramazan.UdemyBlogWebSite.Business.Interfaces;
using Ramazan.UdemyBlogWebSite.Business.ToolsUtilities.JWTTool;
using Ramazan.UdemyBlogWebSite.Dto.DTOs.AppUserDtos;
using Ramazan.UdemyBlogWebSite.WebApi.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }
            return BadRequest("kullanıcı adı veya şifre hatalı");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);
            return Ok(new AppUserDto { Id = user.Id, Name = user.Name, SurName = user.SurName });
        }
    }
}
