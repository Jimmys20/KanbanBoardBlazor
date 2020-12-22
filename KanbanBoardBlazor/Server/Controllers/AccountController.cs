using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Interfaces;
using KanbanBoardBlazor.Server.Models;
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

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register()
        {

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

        public void Logout()
        {

        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.UTF8.GetBytes("secret");
            var securityKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //SecurityAlgorithms.HmacSha256Signature

            var claims = new Claim[]
            {

            };

            var token = new JwtSecurityToken
            (
                claims: claims,

                signingCredentials: credentials

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
