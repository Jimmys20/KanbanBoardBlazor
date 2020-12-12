using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    public class Issue
    {
        public long issueId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime? deadline { get; set; }

        public Priority priority { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        public bool isOpen { get; set; }

        public long? stageId { get; set; }
        public Stage stage { get; set; }

        public long? projectId { get; set; }
        public Project project { get; set; }

        public List<Assignment> assignees { get; set; }
    }
}
