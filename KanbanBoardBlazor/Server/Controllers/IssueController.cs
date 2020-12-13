using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IssueDto> CreateAsync(IssueDto issue)
        {
            var issueEntity = mapper.Map<Issue>(issue);

            //foreach (var user in issueEntity.assignees)
            //{
            //    user.state = SQWEntityState.esModified;
            //}

            await issueRepository.save(issueEntity);

            issue.issueId = issueEntity.IssueId;
            issue.createdAt = issueEntity.CreatedAt;
     

            return issue;
        }

        [HttpPut("{id}")]
        public async Task<IssueDto> UpdateAsync(long id, IssueDto issue)
        {
            var issueEntity = await issueRepository.Get(id);

            mapper.Map(issue, issueEntity);

            //foreach(var user in issueEntity.assignees)
            //{
            //    user.state = SQWEntityState.esUnmodified;
            //}

            //issueEntity.state = SQWEntityState.esModified;

            await issueRepository.save(issueEntity);

            issue.updatedAt = issueEntity.UpdatedAt;

            return issue;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            //await issueRepository.save(new Issue
            //{
            //    issueId = id,
            //    state = SQWEntityState.esDeleted
            //});
        }
    }
}
