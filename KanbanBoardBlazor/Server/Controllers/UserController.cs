using AutoMapper;
using KanbanBoardBlazor.Server.Dal.Interfaces;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            var userEntities = await userRepository.getAllUsers();
            var users = mapper.Map<List<UserDto>>(userEntities);

            return users.OrderBy(u => u.FullName).ToList();
        }
    }
}
