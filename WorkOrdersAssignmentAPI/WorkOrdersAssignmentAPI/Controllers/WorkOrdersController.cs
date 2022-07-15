using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrdersAssignmentAPI.BusinessLogic.Interfaces;
using WorkOrdersAssignmentAPI.Common.DTOs;

namespace WorkOrdersAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly IWorkOrders _workOrders;

        public WorkOrdersController(IWorkOrders workOrders)
        {
            _workOrders = workOrders;
        }

        [HttpGet]
        [Route("{date:DateTime}")]
        public async Task<IActionResult> GetWorkOrdersByDate(DateTime date)
        {
            try
            {
                List<WorkOrderResponse> workOrders = await this._workOrders
                    .GetWorkOrdersByDate(date);
                return this.Ok(new { Success = true, 
                    Message = "All work orders by date are retreived successfully", 
                    Data = workOrders });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWorkOrdersByTechnicianId(string id)
        {
            try
            {
                List<WorkOrderResponse> workOrders = await this._workOrders
                    .GetWorkOrdersByTechnicianId(id);
                return this.Ok(new { Success = true, 
                    Message = "All work orders assigned to given technician are retreived successfully", 
                    Data = workOrders
                });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkOrder([FromBody] WorkOrderInput newWorkOrder)
        {
            try
            {
                WorkOrderResponse workOrder = await this._workOrders
                    .CreateWorkOrder(newWorkOrder);
                return this.Ok(new { Success = true, 
                    Message = "New work order created successfully", 
                    Data = workOrder});
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpDelete]
        [Route("{workOrderId}")]
        public async Task<IActionResult> DeleteWorkOrderById(string workOrderId)
        {
            try
            {
                await this._workOrders
                    .DeleteWorkOrderById(workOrderId);
                return this.Ok(new
                {
                    Success = true,
                    Message = "Work order deleted successfully"
                });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPut]
        [Route("{workOrderId}")]
        public async Task<IActionResult> UpdateWorkOrderTechnician(string workOrderId, string technicianRegNum)
        {
            try
            {
                WorkOrderResponse workOrder = await this._workOrders
                    .UpdateWorkOrderTechnician(workOrderId, technicianRegNum);
                return this.Ok(new
                {
                    Success = true,
                    Message = "New work order created successfully",
                    Data = workOrder
                });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}
