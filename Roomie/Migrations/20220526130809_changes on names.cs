using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roomie.Migrations
{
    public partial class changesonnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Leaves",
                newName: "Approved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Leaves",
                newName: "IsApproved");
        }
    }
}
