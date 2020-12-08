using KanbanBoardBlazor.Server.Dal.Entities;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class ProjectRepository
    {
        private readonly ISQWWorker worker;

        public ProjectRepository(ISQWWorker worker)
        {
            this.worker = worker;
        }

        public async Task<ProjectEntity> getProjectById(long id)
        {
            ProjectEntity project = null;

            await worker.runAsync(context =>
            {
                project = context
                    .createCommand(@"SELECT *
                                       FROM PANAGIOTIS.PROJECT
                                      WHERE PROJECT_ID = :ID")
                    .addNumericInParam("ID", id)
                    .first<ProjectEntity>();
            });

            return project;
        }
    }
}
