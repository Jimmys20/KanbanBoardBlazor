using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Common.Configuration
{
    public class JwtOptions
    {
        public string Key { get; set; } = "secret";
        public string Issuer { get; set; } = "IssueTrackerApp";
        public string Audience { get; set; } = "IssueTrackerAppAudience";
    }
}
