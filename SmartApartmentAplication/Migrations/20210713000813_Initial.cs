using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartmentAplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mgmtDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mgmtDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mgmtHeader",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mgmtid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mgmtHeader", x => x.id);
                    table.ForeignKey(
                        name: "FK_mgmtHeader_mgmtDetail_mgmtid",
                        column: x => x.mgmtid,
                        principalTable: "mgmtDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mgmtHeader_mgmtid",
                table: "mgmtHeader",
                column: "mgmtid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mgmtHeader");

            migrationBuilder.DropTable(
                name: "mgmtDetail");
        }
    }
}
