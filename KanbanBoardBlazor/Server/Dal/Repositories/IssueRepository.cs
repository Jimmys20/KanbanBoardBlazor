using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class IssueRepository
    {
        private readonly IssueTrackerDbContext context;

        public IssueRepository(IssueTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<Issue> getIssueById(long id)
        {
            Issue issue = null;

            issue = await context.issues
                .Include(i => i.assignees).ThenInclude(a => a.user)
                .FirstOrDefaultAsync(i => i.issueId == id);

            return issue;
        }

        public async Task save(Issue issue)
        {
            //await worker.runAsync(context =>
            //{
            //    context.save(issue);
            //});
        }
    }
}
