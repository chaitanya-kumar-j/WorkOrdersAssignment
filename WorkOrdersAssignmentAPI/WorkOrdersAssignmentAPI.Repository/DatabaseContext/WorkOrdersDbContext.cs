using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Repository.Entities;

namespace WorkOrdersAssignmentAPI.Repository.DatabaseContext
{
    public class WorkOrdersDbContext : DbContext
    {
        public WorkOrdersDbContext(DbContextOptions<WorkOrdersDbContext> options) : base(options)
        {
        }
        public DbSet<Technician> Technicians { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }
    }
}
