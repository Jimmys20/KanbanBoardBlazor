﻿using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("ASSIGNMENT")]
    public class Assignment
    {
        [Column("ISSUE_ID")]
        public long IssueId { get; set; }
        public Issue Issue { get; set; }

        [Column("USER_ID")]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
