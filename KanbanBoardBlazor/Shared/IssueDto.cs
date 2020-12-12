using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
  public class IssueDto
  {
        public long issueId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime? deadline { get; set; }

        public Priority priority { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        public bool isOpen { get; set; }

        public string stageKey { get; set; }
        //public Stage stage { get; set; }

        public long projectId { get; set; }
        //public Project project { get; set; }

        public List<UserDto> assignees { get; set; }
    }
}
