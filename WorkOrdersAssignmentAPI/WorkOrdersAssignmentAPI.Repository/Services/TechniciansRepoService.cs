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
    public class TechniciansRepoService : ITechniciansRepo
    {
        private readonly WorkOrdersDbContext _workOrdersDbContext;

        public TechniciansRepoService(WorkOrdersDbContext workOrdersDbContext)
        {
            _workOrdersDbContext = workOrdersDbContext;
        }
        public async Task<TechnicianResponse> AddTechnicianAsync(TechnicianInput newTechnician)
        {
            try
            {
                Technician technician = new Technician()
                {
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    FirstName = newTechnician.FirstName,
                    LastName = newTechnician.LastName,
                    IsActive = true,
                    DeactivatedDate = null
                    
                };
                _workOrdersDbContext.Technicians.Add(technician);
                await _workOrdersDbContext.SaveChangesAsync();

                return new TechnicianResponse()
                {
                    RegistrationNumber = technician.RegistrationNumber,
                    FirstName = technician.FirstName,
                    LastName = technician.LastName,
                    IsActive = technician.IsActive
                };

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
                var technician = await _workOrdersDbContext.Technicians.FindAsync(technicianRegNum);
                if(technician == null)
                {
                    throw new Exception("No Technician with given Registration Number");
                }
                technician.IsActive = false;
                technician.DeactivatedDate = DateTime.Now.Date;
                await _workOrdersDbContext.SaveChangesAsync();

                return new TechnicianResponse()
                {
                    RegistrationNumber = technician.RegistrationNumber,
                    FirstName = technician.FirstName,
                    LastName = technician.LastName,
                    IsActive = technician.IsActive
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
