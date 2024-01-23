using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text;
using Models;

namespace Controllers
{
    public class SharedController : Controller
    {
        private readonly IConfiguration _configuration;
        protected IUser CurrentUser;

        public SharedController(IConfiguration configuration, IUser user)
        {
            _configuration = configuration;
            CurrentUser = user;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    context.Result = BadRequest(new { error = "Authorization token is missing." });
                    return;
                }

                var user = DecodeJwtToken(token);

                if (user == null)
                {
                    context.Result = Unauthorized(new { error = "Invalid or expired token." });
                    return;
                }



                CurrentUser = (User)user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private object DecodeJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var serializedUser = claimsPrincipal.FindFirst("User").Value;
                return JsonSerializer.Deserialize<User>(serializedUser);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
