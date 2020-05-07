using AutoMapper;
using TierApp.Business.Abstract;
using TierApp.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TierApp.API.Helper;
using TierApp.Core.DTOs;
using System.Threading.Tasks;

namespace TierApp.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IConfiguration configuration, IMapper mapper)
        {
            _authService = authService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<User>(userRegisterDto);

            if (await _authService.Any(userRegisterDto.Email))
            {
                return new ObjectActionResult(success: false, statusCode: HttpStatusCode.OK, data: null);
            }

            var _user = _authService.Register(user);
            var userProfileDto = _mapper.Map<UserProfileDto>(_user);

            return new ObjectActionResult(success: true, statusCode: HttpStatusCode.Created, data: userProfileDto);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var user = _mapper.Map<User>(userLoginDto);
            user = _authService.Login(user);

            if (user == null)
            {
                return new ObjectActionResult(success: false, statusCode: HttpStatusCode.BadRequest, data: null);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Username)
                    //new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenValue = tokenHandler.WriteToken(token);

            return new ObjectActionResult(success: true, statusCode: HttpStatusCode.OK, data: tokenValue);
        }
    }
}