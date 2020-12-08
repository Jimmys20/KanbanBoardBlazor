using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class Project
    {
        public long projectId { get; set; }

        public string name { get; set; }

        public List<Stage> stages { get; set; }

        public List<Issue> issues { get; set; }
    }
}
