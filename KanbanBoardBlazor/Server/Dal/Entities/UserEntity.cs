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
    Constants.SCHEMA,
    TABLE_NAME,
    nameof(userId),
    "USER_ID",
    default(long))]
    public class UserEntity : SQWEntity
    {
        public const string TABLE_NAME = "APP_USER";

        [SQWFieldMap()]
        public long userId { get; set; }

        [SQWFieldMap()]
        public long guardianUserId { get; set; }

        [SQWFieldMap(100)]
        public string lastName { get; set; }

        [SQWFieldMap(100)]
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
                var user = (UserEntity)obj;

                if (user.userId == default(long))
                {
                    return true;
                }

                return false;
            };

            beforeUpdate = (obj, ctx) =>
            {


                return false;
            };
        }
    }
}
