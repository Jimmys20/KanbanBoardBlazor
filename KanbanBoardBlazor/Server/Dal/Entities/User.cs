using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    public class User
    {
        public long userId { get; set; }

        //public long guardianUserId { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public List<Issue> assignments { get; set; }
    }
}
