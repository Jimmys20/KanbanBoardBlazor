using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Shared
{
  public class IssueDto
  {
        public long IssueId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsOpen { get; set; }

        public string StageKey { get; set; }
        //public Stage stage { get; set; }

        public long? ProjectId { get; set; }
        //public Project project { get; set; }

        public long? ApplicationId { get; set; }
        public ApplicationDto Application { get; set; }

        public List<UserDto> Assignees { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<CustomerDto> Customers { get; set; }

        public string AssigneesStr
        {
            get
            {
                if (Assignees != null && Assignees.Any())
                {
                    return string.Join("###", Assignees.Select(a => a.UserId));
                }
                else
                {
                    return null;
                }
            }
        }

        public string CustomersStr
        {
            get
            {
                if (Customers != null && Customers.Any())
                {
                    return string.Join("###", Customers.Select(c => c.CustomerId));
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
