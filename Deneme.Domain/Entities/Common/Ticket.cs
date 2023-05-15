using Deneme.Domain.Common;
using Registalaser.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Domain.Entities.Common
{
    public class Ticket : BaseEntity
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Durum")]
        public TicketStatus TicketStatus { get; set; }

        [DisplayName("Açıklama/Not")]
        public string? Desc { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
