using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("APPLICATION")]
    public class Application
    {
        [Column("APPLICATION_ID")]
        public long ApplicationId { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
