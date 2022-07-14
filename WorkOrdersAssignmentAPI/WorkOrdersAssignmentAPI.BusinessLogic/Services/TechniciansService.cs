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
    public class TechniciansService : ITechnicians
    {
        private readonly ITechniciansRepo _techniciansRepo;

        public TechniciansService(ITechniciansRepo techniciansRepo)
        {
            _techniciansRepo = techniciansRepo;
        }
        public async Task<TechnicianResponse> AddTechnicianAsync(TechnicianInput newTechnician)
        {
            try
            {
                return await _techniciansRepo.AddTechnicianAsync(newTechnician);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TechnicianResponse> DeactivateTechnicianByIdAsync(string technicianRegNum)
        {
            try
            {
                return await _techniciansRepo.DeactivateTechnicianByIdAsync(technicianRegNum);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
