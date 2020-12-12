using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class UserDto
    {
        public long userId { get; set; }

        public long guardianUserId { get; set; }
        //public string username { get; set; }

        public string lastName { get; set; }

        public string firstName { get; set; }

        public string fullName => $"{lastName} {firstName}";
        public string initials => $"{lastName?[0]}{firstName?[0]}";
    }
}
