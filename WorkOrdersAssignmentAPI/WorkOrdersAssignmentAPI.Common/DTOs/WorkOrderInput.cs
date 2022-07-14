using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrdersAssignmentAPI.Common.DTOs
{
    public class WorkOrderInput
    {
        [Required]
        public string Place { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now.Date;


        [Required]
        public string TechnicianRegNumber { get; set; } = string.Empty;
    }
}
