using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    public class Assignment
    {
        public long assignmentId { get; set; }

        public long issueId { get; set; }
        public Issue issue { get; set; }

        public long userId { get; set; }
        public User user { get; set; }
    }
}
