using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
  public class IssueDto
  {
        public long IssueId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsOpen { get; set; }

        public string StageKey { get; set; }
        //public Stage stage { get; set; }

        public long? ProjectId { get; set; }
        //public Project project { get; set; }

        //public List<UserDto> assignees { get; set; }
    }
}
