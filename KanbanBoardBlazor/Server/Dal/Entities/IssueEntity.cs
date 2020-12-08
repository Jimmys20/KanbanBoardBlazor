using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Shared;
using SQW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [SQWTableMap(
    Constants.SCHEMA,
    TABLE_NAME,
    nameof(issueId),
    "ISSUE_ID",
    default(long))]
    public class IssueEntity : SQWEntity
    {
        public const string TABLE_NAME = "ISSUE";

        [SQWFieldMap()]
        public long issueId { get; set; }

        [SQWFieldMap(100)]
        public string title { get; set; }

        [SQWFieldMap(300)]
        public string description { get; set; }

        [SQWFieldMap()]
        public DateTime? deadline { get; set; }

        [SQWFieldMap(10)]
        public Priority priority { get; set; }

        [SQWFieldMap()]
        public DateTime createdAt { get; set; }

        [SQWFieldMap()]
        public DateTime? updatedAt { get; set; }

        [SQWFieldMap(50)]
        public string assignee { get; set; }

        [SQWFieldMap()]
        public bool isOpen { get; set; }

        [SQWFieldMap()]
        public long? stageId { get; set; }
        [SQWMany2OneMap(
          Constants.SCHEMA,
          StageEntity.TABLE_NAME,
          nameof(StageEntity.stageId),
          "STAGE_ID",
          nameof(IssueEntity.stageId),
          "STAGE_ID")]
        public StageEntity stage { get; set; }

        [SQWFieldMap()]
        public long projectId { get; set; }
        [SQWMany2OneMap(
          Constants.SCHEMA,
          ProjectEntity.TABLE_NAME,
          nameof(ProjectEntity.projectId),
          "PROJECT_ID",
          nameof(IssueEntity.projectId),
          "PROJECT_ID")]
        public ProjectEntity project { get; set; }

        public IssueEntity()
        {
            beforeInsert = (obj, ctx) =>
            {
                var issue = (IssueEntity)obj;
                issue.createdAt = ctx.scalar<DateTime>("SELECT SYSDATE FROM DUAL");

                return true;
            };

            beforeUpdate = (obj, ctx) =>
            {
                var issue = (IssueEntity)obj;
                issue.updatedAt = ctx.scalar<DateTime>("SELECT SYSDATE FROM DUAL");

                return true;
            };
        }
    }
}
