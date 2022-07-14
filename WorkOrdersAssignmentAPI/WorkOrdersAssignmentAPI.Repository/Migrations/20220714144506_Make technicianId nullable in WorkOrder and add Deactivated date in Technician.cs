using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkOrdersAssignmentAPI.Repository.Migrations
{
    public partial class MaketechnicianIdnullableinWorkOrderandaddDeactivateddateinTechnician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicianRegNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedDate",
                table: "Technicians",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicianRegNumber",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "DeactivatedDate",
                table: "Technicians");
        }
    }
}
