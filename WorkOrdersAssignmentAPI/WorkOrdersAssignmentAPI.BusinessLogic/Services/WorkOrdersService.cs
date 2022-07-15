using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.BusinessLogic.Interfaces;
using WorkOrdersAssignmentAPI.Common.DTOs;
using WorkOrdersAssignmentAPI.Repository.Interfaces;

namespace WorkOrdersAssignmentAPI.BusinessLogic.Services
{
    public class WorkOrdersService : IWorkOrders
    {
        private readonly IWorkOrdersRepo _workOrdersRepo;

        public WorkOrdersService(IWorkOrdersRepo workOrdersRepo)
        {
            _workOrdersRepo = workOrdersRepo;
        }

        public async Task<List<WorkOrderResponse>> GetWorkOrdersByDateAsync(DateTime date)
        {
            try
            {
                return await _workOrdersRepo.GetWorkOrdersByDateAsync(date);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<WorkOrderResponse>> GetWorkOrdersByTechnicianIdAsync(string technicianRegNum)
        {
            try
            {
                return await _workOrdersRepo.GetWorkOrdersByTechnicianIdAsync(technicianRegNum);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WorkOrderResponse> CreateWorkOrderAsync(WorkOrderInput newWorkOrder)
        {
            try
            {
                return await _workOrdersRepo.CreateWorkOrderAsync(newWorkOrder);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteWorkOrderByIdAsync(string workOrderId)
        {
            try
            {
                await _workOrdersRepo.DeleteWorkOrderByIdAsync(workOrderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WorkOrderResponse> UpdateWorkOrderTechnicianAsync(string workOrderId, string technicianRegNum)
        {
            try
            {
                return await _workOrdersRepo.UpdateWorkOrderTechnicianAsync(workOrderId, technicianRegNum);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
