using SQW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [SQWTableMap(
    "GUARDIAN",
    "USER_MASTER",
    nameof(userId),
    "USER_LINK",
    default(long))]
    public class UserEntity
    {
        [SQWFieldMap("USER_LINK")]
        public long userId { get; set; }

        [SQWFieldMap("USER_ID")]
        public string username { get; set; }

        [SQWFieldMap("LAST_NAME")]
        public string lastName { get; set; }

        [SQWFieldMap("FIRST_NAME")]
        public string firstName { get; set; }
    }
}
