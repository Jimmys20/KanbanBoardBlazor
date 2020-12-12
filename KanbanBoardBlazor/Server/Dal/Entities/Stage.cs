﻿using KanbanBoardBlazor.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    public class Stage
    {
        public long stageId { get; set; }

        public int position { get; set; }

        public string title { get; set; }

        public string color { get; set; }

        public int? limit { get; set; }

        public long projectId { get; set; }
        public Project project { get; set; }

        public List<Issue> issues { get; set; }
    }
}