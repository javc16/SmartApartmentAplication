using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartmentAplication.Migrations
{
    public partial class AddingMgmtIDField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mgmtID",
                table: "mgmtDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mgmtID",
                table: "mgmtDetail");
        }
    }
}
