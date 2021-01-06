using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext context;

        public ProjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Project> getProjectById(long id)
        {
            Project project = null;

            project = await context.Projects
                .Include(p => p.Stages)
                .Include(p => p.Issues).ThenInclude(i => i.Application)
                .Include(p => p.Issues).ThenInclude(i => i.Assignees).ThenInclude(a => a.User)
                .Include(p => p.Issues).ThenInclude(i => i.IssueTags).ThenInclude(a => a.Tag)
                .Include(p => p.Issues).ThenInclude(i => i.IssueCustomers).ThenInclude(a => a.Customer)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            return project;
        }

        public async Task save(Project project)
        {
            //await worker.runAsync(context =>
            //{
            //    context.save(project);
            //});
        }
    }
}
