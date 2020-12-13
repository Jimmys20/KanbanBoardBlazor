using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("APP_USER")]
    public class User
    {
        [Column("USER_ID")]
        public long UserId { get; set; }

        //public long guardianUserId { get; set; }

        [Column("LAST_NAME")]
        public string LastName { get; set; }

        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}
