using KanbanBoardBlazor.Server.Common.Configuration;
using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Interfaces;
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
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtOptions _jwtOptions;

        public AccountController(IUserRepository userRepository, JwtOptions jwtOptions)
        {
            _userRepository = userRepository;
            _jwtOptions = jwtOptions;
        }

        public IActionResult Register(LoginInputModel model)
        {
            _userRepository.RegisterUser(model.Username, model.Password);

            return Ok();
        }

        public IActionResult Login(LoginInputModel model)
        {
            if (_userRepository.ValidateCredentials(model.Username, model.Password))
            {
                var user = _userRepository.GetUserByUsername(model.Username);

                if (user != null)
                {
                    var token = GenerateJwtToken(user);

                    return Ok(new
                    {
                        token
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
