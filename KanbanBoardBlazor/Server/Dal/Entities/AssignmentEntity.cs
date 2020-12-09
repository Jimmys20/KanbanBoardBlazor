using KanbanBoardBlazor.Server.Common;
using SQW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [SQWTableMap(Constants.SCHEMA, TABLE_NAME, null, null, null)]
    public class AssignmentEntity
    {
        public const string TABLE_NAME = "ASSIGNMENT";

        [SQWFieldMap()]
        public long issueId { get; set; }

        [SQWFieldMap()]
        public long userId { get; set; }
    }
}
