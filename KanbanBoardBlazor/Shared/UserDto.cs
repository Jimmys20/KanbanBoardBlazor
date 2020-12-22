using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
    public class UserDto
    {
        public long UserId { get; set; }

        //public long guardianUserId { get; set; }
        //public string username { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string Initials => $"{FirstName?[0]}{LastName?[0]}";
    }
}
