using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;

namespace WorkOrdersAssignmentAPI.Repository.Interfaces
{
    public interface IWorkOrdersRepo
    {
        Task<List<WorkOrderResponse>> GetWorkOrdersByDateAsync(DateTime date);

        Task<List<WorkOrderResponse>> GetWorkOrdersByTechnicianIdAsync(string technicianRegNum);

        Task<WorkOrderResponse> CreateWorkOrderAsync(WorkOrderInput newWorkOrder);

        Task DeleteWorkOrderByIdAsync(string workOrderId);

        Task<WorkOrderResponse> UpdateWorkOrderTechnicianAsync(string workOrderId, string technicianRegNum);
    }
}
