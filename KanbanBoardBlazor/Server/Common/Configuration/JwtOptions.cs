using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Common.Configuration
{
    public class JwtOptions
    {
        public string Key { get; set; } = "sdioas9djD*(JD(sdjas89jd0qj9jasjd89asdj288282";
        public string Issuer { get; set; } = "IssueTrackerApp";
        public string Audience { get; set; } = "IssueTrackerAppAudience";
    }
}
