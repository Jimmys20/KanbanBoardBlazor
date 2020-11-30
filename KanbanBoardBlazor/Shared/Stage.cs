using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class Stage
    {
        public string title { get; set; }

        public List<Issue> issues { get; set; } = new List<Issue>();
    }
}
