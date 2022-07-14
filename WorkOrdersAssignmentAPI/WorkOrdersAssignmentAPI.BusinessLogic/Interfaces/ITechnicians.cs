using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;

namespace WorkOrdersAssignmentAPI.BusinessLogic.Interfaces
{
    public interface ITechnicians
    {
        Task<TechnicianResponse> AddTechnicianAsync(TechnicianInput newTechnician);

        Task<TechnicianResponse> DeactivateTechnicianByIdAsync(string technicianRegNum);
    }
}
