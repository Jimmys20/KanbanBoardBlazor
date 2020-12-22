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
    public class TagController : ControllerBase
    {
        private readonly TagRepository tagRepository;
        private readonly IMapper mapper;

        public TagController(TagRepository tagRepository, IMapper mapper)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<TagDto>> Get()
        {
            var tagEntities = await tagRepository.getAllTags();
            var tags = mapper.Map<List<TagDto>>(tagEntities);

            return tags;

        }
    }
}
