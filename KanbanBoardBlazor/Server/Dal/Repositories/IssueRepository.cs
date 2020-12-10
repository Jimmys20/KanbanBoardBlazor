using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class IssueRepository
    {
        private readonly ISQWWorker worker;

        public IssueRepository(ISQWWorker worker)
        {
            this.worker = worker;
        }

        public async Task<IssueEntity> getIssueById(long id)
        {
            IssueEntity issue = null;

            await worker.runAsync(context =>
            {
                issue = context
                    .createCommand($@"SELECT *
                                       FROM {Constants.SCHEMA}.ISSUE
                                      WHERE ISSUE_ID = :ID")
                    .addNumericInParam("ID", id)
                    .first<IssueEntity>();
            });

            return issue;
        }

        public async Task save(IssueEntity issue)
        {
            await worker.runAsync(context =>
            {
                context.save(issue);
            });
        }
    }
}
