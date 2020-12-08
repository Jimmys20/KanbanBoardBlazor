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
    nameof(stageId),
    "STAGE_ID",
    default(string))]
    public class StageEntity : SQWEntity
    {
        public const string TABLE_NAME = "STAGE";

        [SQWFieldMap()]
        public long stageId { get; set; }
        //[SQWFieldMap()]
        //public string stageKey { get; set; }

        [SQWFieldMap()]
        public int position { get; set; }

        [SQWFieldMap(100)]
        public string title { get; set; }

        [SQWFieldMap(20)]
        public string color { get; set; }

        [SQWFieldMap()]
        public int? limit { get; set; }

        [SQWFieldMap()]
        public long projectId { get; set; }
        [SQWMany2OneMap(
          Constants.SCHEMA,
          ProjectEntity.TABLE_NAME,
          nameof(ProjectEntity.projectId),
          "PROJECT_ID",
          nameof(StageEntity.projectId),
          "PROJECT_ID")]
        public ProjectEntity project { get; set; }

        [SQWOne2ManyMap(
          Constants.SCHEMA,
          IssueEntity.TABLE_NAME,
          nameof(StageEntity.stageId),
          "STAGE_ID",
          nameof(IssueEntity.stageId),
          "STAGE_ID")]
        public List<IssueEntity> issues { get; set; }
    }
}
