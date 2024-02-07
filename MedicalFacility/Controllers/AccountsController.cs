using AutoMapper;
using MedicalFacility.DTOs;
using MedicalFacility.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace MedicalFacility.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly MainDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AccountsController(MainDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromQuery] LoginRequestDtO loginRequest)
        {
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(loginRequest.Password, salt);
            await _context.Users.AddAsync(new User { Login = loginRequest.Login, Password = hashedPassword, Salt = salt });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromQuery] LoginRequestDtO loginRequest)
        {
            var user = _context.Users.Where(x => x.Login == loginRequest.Login).FirstOrDefault();
            var hashedPassword = HashPassword(loginRequest.Password, user.Salt);

            if (hashedPassword != user.Password)
                return Unauthorized();

            var refreshToken = GenerateSalt();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiration = DateTime.Now.AddHours(1);
            _context.SaveChanges();

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(GenerateAccessToken()),
                refreshToken
            });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] string refreshTokenRequest)
        {
            var user = _context.Users.SingleOrDefault(x => x.RefreshToken == refreshTokenRequest);

            if (user == null)
                return Unauthorized("Invalid refresh token.");

            if (user.RefreshTokenExpiration.Value < DateTime.Now)
                return Unauthorized("Refresh token expired.");  

            var newAccessToken = GenerateAccessToken();
            var newRefreshToken = GenerateSalt();
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();

            return Ok(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        private JwtSecurityToken GenerateAccessToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            return new JwtSecurityToken(
                issuer: _configuration.GetSection("JwtSettings:ValidIssuer").Value,
                audience: _configuration.GetSection("JwtSettings:ValidAudience").Value,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        }

        private static string GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        private static string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32));
        }
    }
}
