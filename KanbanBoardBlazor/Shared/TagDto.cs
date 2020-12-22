using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class TagDto
    {
        public long TagId { get; set; }

        public string Text { get; set; }

        public string CssClass { get; set; }
    }
}
