using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Common.Configuration
{
    public class DatabaseOptions
    {
        public string host { get; set; }
        public string instance { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
