using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ramazan.UdemyBlogWebSite.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public ImagesController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogImageById(int id)
        {
            var blog = await _blogService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(blog.ImagePath))
            {
                return NotFound("resim yok");
            }
            return File($"/img/{blog.ImagePath}", "image/jpeg");
        }
    }
}
