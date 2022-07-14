using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;
using WorkOrdersAssignmentAPI.Repository.DatabaseContext;
using WorkOrdersAssignmentAPI.Repository.Interfaces;

namespace WorkOrdersAssignmentAPI.Repository.Services
{
    public class WorkOrdersRepoService : IWorkOrdersRepo
    {
        private readonly WorkOrdersDbContext _workOrdersDbContext;

        public WorkOrdersRepoService(WorkOrdersDbContext workOrdersDbContext)
        {
            _workOrdersDbContext = workOrdersDbContext;
        }
        public Task<WorkOrderResponse> CreateWorkOrder(WorkOrderInput newWorkOrder)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkOrderById(string workOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkOrderResponse>> GetWorkOrdersByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkOrderResponse>> GetWorkOrdersByTechnicianId(string technicianRegNum)
        {
            throw new NotImplementedException();
        }

        public Task<WorkOrderResponse> UpdateWorkOrderTechnician(string workOrderId, string technicianRegNum)
        {
            throw new NotImplementedException();
        }
    }
}
