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

        public async Task<List<WorkOrderResponse>> GetWorkOrdersByDate(DateTime date)
        {
            try
            {
                return await _workOrdersRepo.GetWorkOrdersByDate(date);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<WorkOrderResponse>> GetWorkOrdersByTechnicianId(string technicianRegNum)
        {
            try
            {
                return await _workOrdersRepo.GetWorkOrdersByTechnicianId(technicianRegNum);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WorkOrderResponse> CreateWorkOrder(WorkOrderInput newWorkOrder)
        {
            try
            {
                return await _workOrdersRepo.CreateWorkOrder(newWorkOrder);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteWorkOrderById(string workOrderId)
        {
            try
            {
                await _workOrdersRepo.DeleteWorkOrderById(workOrderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<WorkOrderResponse> UpdateWorkOrderTechnician(string workOrderId, string technicianRegNum)
        {
            try
            {
                return await _workOrdersRepo.UpdateWorkOrderTechnician(workOrderId, technicianRegNum);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
