using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class StageDto
    {
        public string StageKey { get; set; }

        public int Position { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public int? Limit { get; set; }

        public long ProjectId { get; set; }
        //public Project project { get; set; }

        //public List<Issue> issues { get; set; }
    }
}
