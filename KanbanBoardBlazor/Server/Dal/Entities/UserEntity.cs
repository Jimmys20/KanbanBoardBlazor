using KanbanBoardBlazor.Server.Common;
using SQW;
using SQW.Interfaces;
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
    public class UserEntity : SQWEntity
    {
        [SQWFieldMap("USER_LINK")]
        public long userId { get; set; }

        [SQWFieldMap("USER_ID")]
        public string username { get; set; }

        [SQWFieldMap("LAST_NAME")]
        public string lastName { get; set; }

        [SQWFieldMap("FIRST_NAME")]
        public string firstName { get; set; }

        [SQWMany2ManyMap(
            Constants.SCHEMA,
            AssignmentEntity.TABLE_NAME,
            "USER_ID",
            "ISSUE_ID",
            nameof(userId),
            "USER_ID")]
        public List<IssueEntity> assignments { get; set; }

        public UserEntity()
        {
            beforeInsert = (obj, ctx) =>
            {
                return false;
            };

            beforeUpdate = (obj, ctx) =>
            {
                return false;
            };
        }
    }
}
