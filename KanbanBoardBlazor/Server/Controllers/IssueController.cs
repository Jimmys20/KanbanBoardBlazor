using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace KanbanBoardBlazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public IssueController(IssueRepository issueRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IssueDto> CreateAsync(IssueDto issue)
        {
            var issueEntity = _mapper.Map<Issue>(issue);

            //foreach (var user in issueEntity.assignees)
            //{
            //    user.state = SQWEntityState.esModified;
            //}

            issueEntity.CreatedAt = DateTime.UtcNow;

            issueEntity.Application = null;

            await _issueRepository.Create(issueEntity);

            issue.IssueId = issueEntity.IssueId;
            issue.CreatedAt = issueEntity.CreatedAt;
     

            return issue;
        }

        [HttpPut("{id}")]
        public async Task<IssueDto> UpdateAsync(long id, IssueDto issue)
        {
            var issueEntity = await _issueRepository.Get(id);

            _mapper.Map(issue, issueEntity);

            //foreach(var user in issueEntity.assignees)
            //{
            //    user.state = SQWEntityState.esUnmodified;
            //}

            //issueEntity.state = SQWEntityState.esModified;

            issueEntity.UpdatedAt = DateTime.UtcNow;

            await _issueRepository.Update(issueEntity);

            issue.UpdatedAt = issueEntity.UpdatedAt;

            return issue;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(long id)
        {
            await _issueRepository.Delete(id);
        }
    }
}
