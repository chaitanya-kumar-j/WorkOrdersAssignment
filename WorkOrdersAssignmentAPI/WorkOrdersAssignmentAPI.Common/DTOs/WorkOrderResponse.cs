using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrdersAssignmentAPI.Common.DTOs
{
    public class WorkOrderResponse
    {
        public string? WorkOrderId { get; set; }

        public string? Place { get; set; }

        public DateTime CreatedAt { get; set; }

        public TechnicianResponse? Technician { get; set; }
    }
}
