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
        private readonly INotifications _notifications;
        private readonly ILogger<WorkOrdersController> _logger;

        public WorkOrdersController(IWorkOrders workOrders, INotifications notifications, ILogger<WorkOrdersController> logger)
        {
            _workOrders = workOrders;
            _notifications = notifications;
            _logger = logger;
        }

        /// <summary>
        /// Retreives all work orders assigned for particular date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of work orders assigned for given date</returns>
        [HttpGet]
        [Route("{date:DateTime}")]
        public async Task<IActionResult> GetWorkOrdersByDateAsync(DateTime date)
        {
            try
            {
                _logger.LogInformation("Requesing GetWorkOrdersByDateAsync...");
                List<WorkOrderResponse> workOrders = await this._workOrders
                    .GetWorkOrdersByDateAsync(date);
                _logger.LogInformation("GetWorkOrdersByDateAsync Request is successful...");
                return this.Ok(new { Success = true, 
                    Message = "All work orders by date are retreived successfully", 
                    Data = workOrders });
            }
            catch (Exception e)
            {
                _logger.LogError($"GetWorkOrdersByDateAsync Request got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Retreives all work orders assigned for particular technician
        /// </summary>
        /// <param name="technicianRegNum"></param>
        /// <returns>List of work orders assigned for given technician</returns>
        [HttpGet]
        public async Task<IActionResult> GetWorkOrdersByTechnicianIdAsync(string technicianRegNum)
        {
            try
            {
                _logger.LogInformation("Requesting GetWorkOrdersByTechnicianIdAsync...");
                List<WorkOrderResponse> workOrders = await this._workOrders
                    .GetWorkOrdersByTechnicianIdAsync(technicianRegNum);
                _logger.LogInformation("Request to GetWorkOrdersByTechnicianIdAsync is successful...");
                return this.Ok(new { Success = true, 
                    Message = "All work orders assigned to given technician are retreived successfully", 
                    Data = workOrders
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"GetWorkOrdersByTechnicianIdAsync Request got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Creates new work order
        /// </summary>
        /// <param name="newWorkOrder"></param>
        /// <returns> Returns created work order details</returns>
        [HttpPost]
        public async Task<IActionResult> CreateWorkOrderAsync([FromBody] WorkOrderInput newWorkOrder)
        {
            try
            {
                _logger.LogInformation("Requesting CreateWorkOrderAsync...");
                WorkOrderResponse workOrder = await this._workOrders
                    .CreateWorkOrderAsync(newWorkOrder);
                if (workOrder.Technician != null)
                {
                    NotificationDTO notificationDTO = new NotificationDTO()
                    {
                        TechnicianRegNum = workOrder.Technician.RegistrationNumber,
                        Message = $"You have been assigned to a work Order with reference Id {workOrder.WorkOrderId}",

                    };
                    _notifications.SendNotification(notificationDTO);
                }
                _logger.LogInformation("Request to CreateWorkOrderAsync is successful...");
                return this.Ok(new { Success = true, 
                    Message = "New work order created successfully", 
                    Data = workOrder});
            }
            catch (Exception e)
            {
                _logger.LogError($"CreateWorkOrderAsync Request got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Deletes the work order of specified work order id
        /// </summary>
        /// <param name="workOrderId"></param>
        /// <returns>Delete action status</returns>
        [HttpDelete]
        [Route("{workOrderId}")]
        public async Task<IActionResult> DeleteWorkOrderByIdAsync(string workOrderId)
        {
            try
            {
                _logger.LogInformation("Requesting DeleteWorkOrderByIdAsync...");
                await this._workOrders.DeleteWorkOrderByIdAsync(workOrderId);
                _logger.LogInformation("Request to DeleteWorkOrderByIdAsync is successful...");
                return this.Ok(new
                {
                    Success = true,
                    Message = "Work order deleted successfully"
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"DeleteWorkOrderByIdAsync Request got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates/Adds new technician to given work order
        /// </summary>
        /// <param name="workOrderId"></param>
        /// <param name="technicianRegNum"></param>
        /// <returns>Returns updated work order details</returns>
        [HttpPut]
        [Route("{workOrderId}")]
        public async Task<IActionResult> UpdateWorkOrderTechnicianAsync(string workOrderId, string technicianRegNum)
        {
            try
            {
                _logger.LogInformation("Requesting UpdateWorkOrderTechnicianAsync...");
                WorkOrderResponse workOrder = await this._workOrders
                    .UpdateWorkOrderTechnicianAsync(workOrderId, technicianRegNum);
                _logger.LogInformation("Request to UpdateWorkOrderTechnicianAsync is successful...");
                if (workOrder.Technician != null)
                {
                    NotificationDTO notificationDTO = new NotificationDTO()
                    {
                        TechnicianRegNum = workOrder.Technician.RegistrationNumber,
                        Message = $"You have been assigned to a work Order with reference Id {workOrder.WorkOrderId}",

                    };
                    _notifications.SendNotification(notificationDTO);
                }
                return this.Ok(new
                {
                    Success = true,
                    Message = "New work order created successfully",
                    Data = workOrder
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"UpdateWorkOrderTechnicianAsync Request got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}
