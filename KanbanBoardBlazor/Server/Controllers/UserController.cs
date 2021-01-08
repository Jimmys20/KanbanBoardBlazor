using AutoMapper;
using KanbanBoardBlazor.Server.Common.Configuration;
using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Interfaces;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;

        public UserController(IUserRepository userRepository,
                              IMapper mapper,
                              JwtOptions jwtOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtOptions = jwtOptions;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            var userEntities = await _userRepository.getAllUsers();
            var users = _mapper.Map<List<UserDto>>(userEntities);

            return users.OrderBy(u => u.FullName).ToList();
        }

        [HttpGet("Register")]
        public IActionResult Register(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);

            if (user == null)
            {
                _userRepository.RegisterUser(username, password);

                return Ok("User registered successfully");
            }

            return BadRequest("User already exists");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginInputModel model)
        {
            if (_userRepository.ValidateCredentials(model.Username, model.Password))
            {
                var user = _userRepository.GetUserByUsername(model.Username);

                if (user != null)
                {
                    var token = GenerateJwtToken(user);

                    return Ok(new LoginResult
                    {
                        Token = token
                    });
                }
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Key);
            var securityKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //SecurityAlgorithms.HmacSha256Signature

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken
            (
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
