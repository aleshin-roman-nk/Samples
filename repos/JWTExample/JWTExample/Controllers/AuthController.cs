﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePassowrHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if(user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password wrong");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        [HttpGet]
        public IActionResult Get()
        {
			var username = User.Identity?.Name;
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			//var customClaimValue = User.FindFirst("YourCustomClaim")?.Value;
			var roleClaimValue = User.FindFirst(ClaimTypes.Role)?.Value;

			// Use the extracted information as needed
			// ...

			return Ok(new { Username = username, UserId = userId, RoleClaim = roleClaimValue });
		}

        private void CreatePassowrHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

		//private string CreateToken(User user)
		//{
		//    List<Claim> claims = new List<Claim>
		//    {
		//        new Claim(ClaimTypes.Name, user.Username)

		//    };

		//    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

		//    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		//    var token = new JwtSecurityToken(
		//        claims: claims,
		//        expires: DateTime.Now.AddDays(1),
		//        signingCredentials: cred
		//        );

		//    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		//    return jwt;
		//}


		private string CreateToken(User user)
		{

			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, "Admin")
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
				_configuration.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
