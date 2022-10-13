using Microsoft.AspNetCore.Http;
using CarShopApi.Web.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static CarShopApi.Web.Areas.Identity.Pages.Account.LoginModel;
using CarShopApi.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CarShopApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<CarShopApiWebUser> _userManager;

        public TokenController(UserManager<CarShopApiWebUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] InputModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if(user == null || !await _userManager.CheckPasswordAsync(user, model.Password)){
                return Unauthorized();
            }
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("qu!te $Ecretaaaaaaa"));
            var decriptorToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(decriptorToken);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expires = token.ValidTo
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("Vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:7046/Vehicles");
            var data = await response.Content.ReadAsStringAsync();

            return Ok(data);
        }
    }
}
