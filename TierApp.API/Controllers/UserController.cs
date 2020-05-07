using TierApp.API.Helper;
using TierApp.Business.Abstract;
using TierApp.Core.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace TierApp.API.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [Authorize]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.GetUser(userId);

            if (user == null)
                return BadRequest();

            var userProfileDto = _mapper.Map<UserProfileDto>(user);

            return new ObjectActionResult(success: true, statusCode: HttpStatusCode.OK, data: userProfileDto);
        }
    }
}