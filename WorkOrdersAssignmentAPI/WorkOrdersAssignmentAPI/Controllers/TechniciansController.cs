using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrdersAssignmentAPI.BusinessLogic.Interfaces;
using WorkOrdersAssignmentAPI.Common.DTOs;

namespace WorkOrdersAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicians _technicians;
        private readonly ILogger<TechniciansController> _logger;

        public TechniciansController(ITechnicians technicians, ILogger<TechniciansController> logger)
        {
            _technicians = technicians;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddTechnicianAsync([FromBody] TechnicianInput newTechnician)
        {
            try
            {
                _logger.LogInformation("Requesting AddTechnicianAsync...");
                TechnicianResponse technicianResponse = await this._technicians.AddTechnicianAsync(newTechnician);
                _logger.LogInformation("Request to AddTechnicianAsync is successful.");
                return this.Ok(new { Success = true, Message = "New technician added successfully", Data = technicianResponse });
            }
            catch (Exception e)
            {
                _logger.LogError($"Request to AddTechnicianAsync got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPatch]
        [Route("{technicianId}")]
        public async Task<IActionResult> DeactivateTechnicianByIdAsync(string technicianId)
        {
            try
            {
                _logger.LogInformation("Requesting DeactivateTechnicianByIdAsync...");
                TechnicianResponse technicianResponse = await this._technicians.DeactivateTechnicianByIdAsync(technicianId);
                _logger.LogInformation("Request to DeactivateTechnicianByIdAsync is successful.");
                return this.Ok(new { Success = true, Message = "Technician deactivated successfully", Data = technicianResponse });
            }
            catch (Exception e)
            {
                _logger.LogError($"Request to DeactivateTechnicianByIdAsync got exception : {e.Message}");
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}
