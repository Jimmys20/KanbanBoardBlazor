using AutoMapper;
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
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationRepository applicationRepository;
        private readonly IMapper mapper;

        public ApplicationController(ApplicationRepository applicationRepository, IMapper mapper)
        {
            this.applicationRepository = applicationRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ApplicationDto>> Get()
        {
            var applicationEntities = await applicationRepository.getAllApplications();
            var applications = mapper.Map<List<ApplicationDto>>(applicationEntities);

            return applications;

        }
    }
}
