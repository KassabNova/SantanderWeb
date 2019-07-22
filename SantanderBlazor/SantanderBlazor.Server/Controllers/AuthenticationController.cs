using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantanderBlazor.Shared.Models.Entidades.Respuestas;
using SantanderBlazor.Shared.Models.Entidades;
using SantanderBlazor.Server.Models.Helpers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
namespace SantanderBlazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public  bool isAuthenticated()
        {
            string authHeader = this.HttpContext.Request.Headers["Authorization"];
            string jwtEncodedString = authHeader.Substring(7); // trim 'Bearer ' from the start 
            var handler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSecurityKey"]));

            var validationParameters = new TokenValidationParameters()
            {
                ValidAudience = _configuration["JwtAudience"],
                ValidIssuer = _configuration["JwtIssuer"],
                RequireExpirationTime = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero


            };

            try
            {
                SecurityToken validatedToken;
                var principal = handler.ValidateToken(jwtEncodedString, validationParameters, out validatedToken);
            }
            catch (Exception e)
            {

                Console.WriteLine("{0}\n {1}", e.Message, e.StackTrace);
                return false;
            }

            Console.WriteLine();
            return true;
        }
        private string epochDate(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToShortDateString();
        }

    }
}
