using KanbanBoardBlazor.Server.Common;
using KanbanBoardBlazor.Server.Dal.Entities;
using SQW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal
{
    public class SQWOraSequenceGenerator : SQWSequenceGenerator
    {
        public override long nextLong(Type type)
        {
            if (type == typeof(ProjectEntity))
            {
                return sqwContext.scalar<long>($"SELECT {Constants.SCHEMA}.SEQ_PROJECT.NEXTVAL FROM DUAL");
            }
            else if (type == typeof(StageEntity))
            {
                return sqwContext.scalar<long>($"SELECT {Constants.SCHEMA}.SEQ_STAGE.NEXTVAL FROM DUAL");
            }
            else if (type == typeof(IssueEntity))
            {
                return sqwContext.scalar<long>($"SELECT {Constants.SCHEMA}.SEQ_ISSUE.NEXTVAL FROM DUAL");
            }
            else if (type == typeof(UserEntity))
            {
                return sqwContext.scalar<long>($"SELECT {Constants.SCHEMA}.SEQ_APP_USER.NEXTVAL FROM DUAL");
            }

            return base.nextLong(type);
        }
    }
}
