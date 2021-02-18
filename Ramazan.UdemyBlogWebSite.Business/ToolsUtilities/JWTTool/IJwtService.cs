using Ramazan.UdemyBlogWebSite.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.ToolsUtilities.JWTTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
