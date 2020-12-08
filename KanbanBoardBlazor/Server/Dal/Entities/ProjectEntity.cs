using KanbanBoardBlazor.Server.Common;
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
    nameof(projectId),
    "PROJECT_ID",
    default(long))]
    public class ProjectEntity : SQWEntity
    {
        public const string TABLE_NAME = "PROJECT";

        [SQWFieldMap()]
        public long projectId { get; set; }

        [SQWFieldMap(100)]
        public string name { get; set; }

        [SQWOne2ManyMap(
          Constants.SCHEMA,
          StageEntity.TABLE_NAME,
          nameof(ProjectEntity.projectId),
          "PROJECT_ID",
          nameof(StageEntity.projectId),
          "PROJECT_ID")]
        public List<StageEntity> stages { get; set; }

        [SQWOne2ManyMap(
          Constants.SCHEMA,
          IssueEntity.TABLE_NAME,
          nameof(ProjectEntity.projectId),
          "PROJECT_ID",
          nameof(IssueEntity.projectId),
          "PROJECT_ID")]
        public List<IssueEntity> issues { get; set; }
    }
}
