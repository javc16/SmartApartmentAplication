using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartmentAplication.Migrations
{
    public partial class AddingIsActiveFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isActive",
                table: "mgmtHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isActive",
                table: "mgmtDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "mgmtHeader");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "mgmtDetail");
        }
    }
}
