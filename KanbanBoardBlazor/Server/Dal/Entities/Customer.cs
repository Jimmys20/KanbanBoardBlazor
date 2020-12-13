using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Dal.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Column("CUSTOMER_ID")]
        public long CustomerId { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
