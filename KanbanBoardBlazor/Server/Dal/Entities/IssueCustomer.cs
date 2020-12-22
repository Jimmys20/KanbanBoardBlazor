using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("ISSUE_CUSTOMER")]
    public class IssueCustomer
    {
        [Column("ISSUE_ID")]
        public long IssueId { get; set; }
        public Issue Issue { get; set; }

        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
