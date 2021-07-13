using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartApartmentAplication.Migrations
{
    public partial class AddingPropertiesTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propertyDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    formerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    streetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lng = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyDetail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "propertyHeader",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyid = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyHeader", x => x.id);
                    table.ForeignKey(
                        name: "FK_propertyHeader_propertyDetail_propertyid",
                        column: x => x.propertyid,
                        principalTable: "propertyDetail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_propertyHeader_propertyid",
                table: "propertyHeader",
                column: "propertyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propertyHeader");

            migrationBuilder.DropTable(
                name: "propertyDetail");
        }
    }
}
