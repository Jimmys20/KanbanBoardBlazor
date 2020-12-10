using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQW.Interfaces;
using AutoMapper;

namespace KanbanBoardBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IssueRepository issueRepository;
        private readonly IMapper mapper;

        public IssueController(IssueRepository issueRepository, IMapper mapper)
        {
            this.issueRepository = issueRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<long> CreateAsync(Issue issue)
        {
            var issueEntity = mapper.Map<IssueEntity>(issue);

            await issueRepository.save(issueEntity);

            return issueEntity.issueId;
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(long id, Issue issue)
        {
            var issueEntity = await issueRepository.getIssueById(id);

            mapper.Map(issue, issueEntity);

            await issueRepository.save(issueEntity);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            await issueRepository.save(new IssueEntity
            {
                issueId = id,
                state = SQWEntityState.esDeleted
            });
        }
    }
}
