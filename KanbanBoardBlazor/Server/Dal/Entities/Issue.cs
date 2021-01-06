using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("ISSUE")]
    public class Issue
    {
        [Column("ISSUE_ID")]
        public long IssueId { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("DESCRIPTION", TypeName = "NCLOB")]
        public string Description { get; set; }

        [Column("DEADLINE")]
        public DateTime? Deadline { get; set; }

        [Column("PRIORITY")]
        public Priority Priority { get; set; }

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("UPDATED_AT")]
        public DateTime? UpdatedAt { get; set; }

        [Column("IS_OPEN")]
        public bool IsOpen { get; set; }

        [Column("STAGE_ID")]
        public long? StageId { get; set; }
        public Stage Stage { get; set; }

        [Column("PROJECT_ID")]
        public long? ProjectId { get; set; }
        public Project Project { get; set; }

        [Column("APPLICATION_ID")]
        public long? ApplicationId { get; set; }
        public Application Application { get; set; }

        public List<Assignment> Assignees { get; set; }
        public List<IssueTag> IssueTags { get; set; }
        public List<IssueCustomer> IssueCustomers { get; set; }
    }
}
