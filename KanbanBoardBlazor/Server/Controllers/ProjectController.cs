﻿using AutoMapper;
using KanbanBoardBlazor.Server.Dal.Entities;
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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectController(ProjectRepository projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ProjectDto> Get(long id)
        {
            var projectEntity = await projectRepository.getProjectById(id);
            var project = mapper.Map<ProjectDto>(projectEntity);

            project.issues = project.issues.OrderByDescending(i => i.priority).ThenByDescending(i => i.deadline).ToList();

            return project;
        }

        [HttpPut]
        public async Task<ProjectDto> Update(ProjectDto project)
        {
            var projectEntity = await projectRepository.getProjectById(project.projectId);

            mapper.Map(project, projectEntity);

            //var project = await projectRepository.getProjectById(id);

            await projectRepository.save(projectEntity);
            

            return project;
        }
    }
}
