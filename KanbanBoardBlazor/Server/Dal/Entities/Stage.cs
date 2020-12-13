using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("STAGE")]
    public class Stage
    {
        [Column("STAGE_ID")]
        public long StageId { get; set; }

        [Column("POSITION")]
        public int Position { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("COLOR")]
        public string Color { get; set; }

        [Column("LIMIT")]
        public int? Limit { get; set; }

        [Column("PROJECT_ID")]
        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public List<Issue> Issues { get; set; }
    }
}
