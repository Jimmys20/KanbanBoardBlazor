using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Repositories
{
    public class UserRepository
    {
        private readonly IssueTrackerDbContext context;

        public UserRepository(IssueTrackerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> getAllUsers()
        {
            List<User> users = null;

            users = await context.users.ToListAsync();

            return users;
        }
    }
}
