using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class ProjectDto
    {
        public long projectId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isOpen { get; set; }

        public List<StageDto> stages { get; set; }

        public List<IssueDto> issues { get; set; }
    }
}
