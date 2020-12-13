using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("TAG")]
    public class Tag
    {
        [Column("TAG_ID")]
        public long TagId { get; set; }

        [Column("TEXT")]
        public string Text { get; set; }

        [Column("CSS_CLASS")]
        public string CssClass { get; set; }

        public List<IssueTag> IssueTags { get; set; }
    }
}
