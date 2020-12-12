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
        private readonly IssueTrackerDbContext context;

        public ProjectRepository(IssueTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<Project> getProjectById(long id)
        {
            Project project = null;

            project = await context.projects.Include(p => p.stages)
                .Include(p => p.issues).FirstOrDefaultAsync(p => p.projectId == id);

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
