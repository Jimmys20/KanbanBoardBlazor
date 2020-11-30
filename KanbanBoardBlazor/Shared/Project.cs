using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class Project
    {
        public List<Stage> stages { get; set; } = new List<Stage>();
    }
}
