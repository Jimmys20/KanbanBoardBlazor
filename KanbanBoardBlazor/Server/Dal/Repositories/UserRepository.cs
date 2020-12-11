using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using SQW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class UserRepository
    {
        private readonly ISQWWorker worker;

        public UserRepository(ISQWWorker worker)
        {
            this.worker = worker;
        }

        public async Task<List<UserEntity>> getAllUsers()
        {
            List<UserEntity> users = null;

            await worker.runAsync(context =>
            {
                users = context
                    .createCommand($@"SELECT * FROM {Constants.SCHEMA}.APP_USER")
                    .select<UserEntity>();
            });

            return users;
        }
    }
}
