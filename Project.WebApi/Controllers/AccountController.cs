using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using Project.Domain.Services.UserField;
using Project.Domain;
using Project.WebApi;
using Microsoft.AspNetCore.Authorization;
using Project.Domain.Services.CompanyField;
using Project.Domain.Model.DbModels;

namespace TokenApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly CompanyService _companyService;
        public AccountController(UserService userService, CompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
        }


        [HttpGet]
        public object Get()
        {
            return "test";
        }

        [Authorize]
        [HttpGet("tokenInfo")]
        public object GetTokenInfo()
        {
            return User.Claims.Select(x => $"{x.Type}: {x.Value}");
        }


        [HttpPost("token")]
        public async System.Threading.Tasks.Task Token()
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            var name = Request.Form["name"];
            string identifier = email;
            string role = "user";
            if (email.Count < 1) { identifier = name; role = "company"; }
            var identity = GetIdentity(identifier, password, role);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
issuer: AuthOptions.ISSUER,
audience: AuthOptions.AUDIENCE,
notBefore: now,
claims: identity.Claims,
expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(string identifier, string password, string role)
        {
            Member member = new Member();
            if (role == "user")
            {
                member.Id = _userService.FindByPasswordEmail(password, identifier);
            }
            else  member.Id = _companyService.FindByPasswordEmail(password, identifier);
            if (member != null)
            {
                var claims = new List<Claim>
{
new Claim(ClaimsIdentity.DefaultNameClaimType, member.Id.ToString()),
new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
};
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
