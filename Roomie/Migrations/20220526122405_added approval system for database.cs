using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roomie.Migrations
{
    public partial class addedapprovalsystemfordatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Leaves",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Leaves");
        }
    }
}
