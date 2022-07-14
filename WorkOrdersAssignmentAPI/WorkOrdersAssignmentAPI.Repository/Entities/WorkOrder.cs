using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrdersAssignmentAPI.Repository.Entities
{
    public class WorkOrder
    {
        [Key]
        public string WorkOrderId { get; set; } = string.Empty;
       
        [Required]
        public string Place { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
