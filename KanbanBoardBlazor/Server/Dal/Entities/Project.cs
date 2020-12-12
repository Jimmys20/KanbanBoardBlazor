using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    public class Project
    {
        public long projectId { get; set; }

        public string name { get; set; }

        public List<Stage> stages { get; set; }

        public List<Issue> issues { get; set; }
    }
}
