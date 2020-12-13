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
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Issue> Get(long id)
        {
            Issue issue = null;

            issue = await _context.Issues
                .Include(i => i.Assignees).ThenInclude(a => a.User)
                .Include(i => i.IssueTags).ThenInclude(a => a.Tag)
                .FirstOrDefaultAsync(i => i.IssueId == id);

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
