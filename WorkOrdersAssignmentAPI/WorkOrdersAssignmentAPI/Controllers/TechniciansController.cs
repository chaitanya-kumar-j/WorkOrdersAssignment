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

        public TechniciansController(ITechnicians technicians)
        {
            _technicians = technicians;
        }

        [HttpPost]
        public async Task<ActionResult> AddTechnicianAsync([FromBody] TechnicianInput newTechnician)
        {
            try
            {
                TechnicianResponse technicianResponse = await this._technicians.AddTechnicianAsync(newTechnician);
                return this.Ok(new { Success = true, Message = "New technician added successfully", Data = technicianResponse });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPatch]
        [Route("{technicianId}")]
        public async Task<IActionResult> DeactivateTechnicianByIdAsync(string technicianId)
        {
            try
            {
                TechnicianResponse technicianResponse = await this._technicians.DeactivateTechnicianByIdAsync(technicianId);
                return this.Ok(new { Success = true, Message = "Technician deactivated successfully", Data = technicianResponse });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}
