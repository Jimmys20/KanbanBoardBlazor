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

            project = await context.Projects.Include(p => p.Stages)
                .Include(p => p.Issues).FirstOrDefaultAsync(p => p.ProjectId == id);

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
