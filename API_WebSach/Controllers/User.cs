using API_WebSach.EntityView;
using API_WebSach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_WebSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly NxbKimDongContext db;
        private readonly AppSettings _appSettings;
        public User(NxbKimDongContext _db, IOptionsMonitor<AppSettings> appSettings)
        {
            db = _db;
            _appSettings = appSettings.CurrentValue;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = db.TaiKhoans.SingleOrDefault(p => p.TaiKhoan1 == model.userName && p.Password == model.password);
            if (user == null)
            {
                return Ok(new API_Respont
                {

                    Success = false,
                    Message = "Invail user or password"
                });
            }
            else
            { // cấp token
                return Ok(new API_Respont
                {

                    Success = true,
                    Message = "Success!!",
                    Data = GenerateToken(user)
                });
            }
        }

        private string GenerateToken(TaiKhoan nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoiDung.FullName),
                    new Claim(ClaimTypes.Email, nguoiDung.Email),
                    new Claim("UserName", nguoiDung.TaiKhoan1),
                    new Claim("Id", nguoiDung.Id.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString()),

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),SecurityAlgorithms.HmacSha512Signature)
               
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }



















    }
}
