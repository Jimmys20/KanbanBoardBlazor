using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("ISSUE_TAG")]
    public class IssueTag
    {
        [Column("ISSUE_ID")]
        public long IssueId { get; set; }
        public Issue Issue { get; set; }

        [Column("TAG_ID")]
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
