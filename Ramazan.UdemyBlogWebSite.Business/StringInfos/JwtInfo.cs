using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.UdemyBlogWebSite.Business.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost:51921";
        public const string Audience = "http://localhost:5000";
        public const string SecurityKey = "ramazanramazanramazan28";
        public const double Expires = 40;
        /*Configurasyonumu yapmam lazım services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        AddJwtBearer(opt=>{opt.RequireHttpsMetadata=false; opt.TokenValidationParameters= new
        TokenValidationParameters{....}}); Bunun için bir paket indirmemiz lazım JwtBearer paketi*/
    }
}
