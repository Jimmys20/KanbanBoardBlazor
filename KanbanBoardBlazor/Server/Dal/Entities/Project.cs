using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("PROJECT")]
    public class Project
    {
        [Column("PROJECT_ID")]
        public long ProjectId { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("IS_OPEN")]
        public bool IsOpen { get; set; }

        public List<Stage> Stages { get; set; }

        public List<Issue> Issues { get; set; }
    }
}
