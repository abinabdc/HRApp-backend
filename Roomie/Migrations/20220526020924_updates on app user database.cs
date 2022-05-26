using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roomie.Migrations
{
    public partial class updatesonappuserdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOffAvailable",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOffGiven",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SickLeaveAvailable",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SickLeaveGiven",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacationAvailable",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacationGiven",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WFHAvailable",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WFHGiven",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOffAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DayOffGiven",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SickLeaveAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SickLeaveGiven",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VacationAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VacationGiven",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WFHAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WFHGiven",
                table: "AspNetUsers");
        }
    }
}
