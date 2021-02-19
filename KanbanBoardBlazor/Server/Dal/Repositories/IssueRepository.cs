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
                .Include(i => i.IssueCustomers).ThenInclude(a => a.Customer)
                .FirstOrDefaultAsync(i => i.IssueId == id);

            return issue;
        }

        public async Task<List<Issue>> GetAll()
        {
           return await _context.Issues
                .Include(i => i.Assignees).ThenInclude(a => a.User)
                .Include(i => i.IssueTags).ThenInclude(a => a.Tag)
                .Include(i => i.IssueCustomers).ThenInclude(a => a.Customer)
                .Include(i => i.Application)
                .ToListAsync();
        }

    public async Task Create(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Issue issue)
        {
            _context.Issues.Update(issue);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.Issues.Remove(new Issue
            {
                IssueId = id
            });

            await _context.SaveChangesAsync();
        }
    }
}
