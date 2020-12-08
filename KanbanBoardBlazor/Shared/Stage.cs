using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class Stage
    {
        public string stageKey { get; set; }

        public int position { get; set; }

        public string title { get; set; }

        public string color { get; set; }

        public int? limit { get; set; }

        public long projectId { get; set; }
        //public Project project { get; set; }

        //public List<Issue> issues { get; set; }
    }
}
