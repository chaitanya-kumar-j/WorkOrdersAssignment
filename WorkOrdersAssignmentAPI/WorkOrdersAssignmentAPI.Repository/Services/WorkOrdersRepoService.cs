using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;
using WorkOrdersAssignmentAPI.Repository.DatabaseContext;
using WorkOrdersAssignmentAPI.Repository.Entities;
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

        public async Task<List<WorkOrderResponse>> GetWorkOrdersByDateAsync(DateTime date)
        {
            try
            {
                return await ConvertToResponseListAsync(await _workOrdersDbContext.WorkOrders.ToListAsync());
                
                
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
                return await ConvertToResponseListAsync(await _workOrdersDbContext.WorkOrders
                .Where(x => x.TechnicianRegNumber == technicianRegNum)
                .ToListAsync()
                );
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
                WorkOrderResponse workOrderResponse;
                WorkOrder workOrder = new WorkOrder()
                {
                    WorkOrderId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now.Date,
                    Place = newWorkOrder.Place
                };
                if(newWorkOrder.TechnicianRegNumber != null)
                {
                    var technician = await _workOrdersDbContext.Technicians.FindAsync(newWorkOrder.TechnicianRegNumber);
                    if(technician == null || !technician.IsActive)
                    {
                        technician = null;
                        goto Add;
                    }
                    workOrder.TechnicianRegNumber = technician.RegistrationNumber;
                    _workOrdersDbContext.WorkOrders.Add(workOrder);
                    await _workOrdersDbContext.SaveChangesAsync();
                    workOrderResponse = new WorkOrderResponse()
                    {
                        WorkOrderId = workOrder.WorkOrderId,
                        Place = workOrder.Place,
                        CreatedAt = workOrder.CreatedAt,
                    };
                    workOrderResponse.Technician = new TechnicianResponse()
                    {
                        RegistrationNumber = technician.RegistrationNumber,
                        FirstName = technician.FirstName,
                        LastName = technician.LastName,
                        IsActive = technician.IsActive
                    };
                    return workOrderResponse;
                }
                Add: 
                _workOrdersDbContext.WorkOrders.Add(workOrder);
                await _workOrdersDbContext.SaveChangesAsync();

                workOrderResponse = new WorkOrderResponse()
                {
                    WorkOrderId = workOrder.WorkOrderId,
                    Place = workOrder.Place,
                    CreatedAt = workOrder.CreatedAt,
                    Technician = null
                };
                return workOrderResponse;
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
                var workOrder = await _workOrdersDbContext.WorkOrders.FindAsync(workOrderId);
                if(workOrder == null)
                {
                    throw new Exception("No work order with the given order Id.");
                }
                _workOrdersDbContext.WorkOrders.Remove(workOrder);
                await _workOrdersDbContext.SaveChangesAsync();
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
                var workOrder = await _workOrdersDbContext.WorkOrders.FindAsync(workOrderId);
                if (workOrder == null)
                {
                    throw new Exception("No work order with the given order Id.");
                }
                var technician = await _workOrdersDbContext.Technicians.FindAsync(technicianRegNum);
                if(technician == null)
                {
                    throw new Exception("No technician with the given Registration number.");
                }
                if (!technician.IsActive)
                {
                    throw new Exception("The given technician is not active.");
                }

                workOrder.TechnicianRegNumber = technician.RegistrationNumber;
                _workOrdersDbContext.WorkOrders.Update(workOrder);
                await _workOrdersDbContext.SaveChangesAsync();

                WorkOrderResponse workOrderResponse = new WorkOrderResponse()
                {
                    WorkOrderId = workOrder.WorkOrderId,
                    Place = workOrder.Place,
                    CreatedAt = workOrder.CreatedAt,
                };
                workOrderResponse.Technician = new TechnicianResponse()
                {
                    RegistrationNumber = technician.RegistrationNumber,
                    FirstName = technician.FirstName,
                    LastName = technician.LastName,
                    IsActive = technician.IsActive
                };
                return workOrderResponse;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<WorkOrderResponse>> ConvertToResponseListAsync(List<WorkOrder> workOrders)
        {
            List<WorkOrderResponse> result = new List<WorkOrderResponse>();
            foreach (var workOrder in workOrders)
            {
                WorkOrderResponse workOrderResponse = new WorkOrderResponse()
                {
                    WorkOrderId = workOrder.WorkOrderId,
                    Place = workOrder.Place,
                    CreatedAt = workOrder.CreatedAt,
                };
                var technician = await _workOrdersDbContext.Technicians.FindAsync(workOrder.TechnicianRegNumber);
                if(technician != null)
                {
                    workOrderResponse.Technician = new TechnicianResponse()
                    {
                        RegistrationNumber = technician.RegistrationNumber,
                        FirstName = technician.FirstName,
                        LastName = technician.LastName,
                        IsActive = technician.IsActive
                    };
                }
                else
                {
                    workOrderResponse.Technician = null;
                }
                result.Add(workOrderResponse);
            }
            return result;
        }
    }
}
