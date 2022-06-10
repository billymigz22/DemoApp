using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    public partial class CroppingFarmRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cropping",
                columns: table => new
                {
                    CroppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crop = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cropping", x => x.CroppingId);
                });

            migrationBuilder.CreateTable(
                name: "CroppingFarm",
                columns: table => new
                {
                    CroppingsCroppingId = table.Column<int>(type: "int", nullable: false),
                    FarmsFarmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CroppingFarm", x => new { x.CroppingsCroppingId, x.FarmsFarmId });
                    table.ForeignKey(
                        name: "FK_CroppingFarm_Cropping_CroppingsCroppingId",
                        column: x => x.CroppingsCroppingId,
                        principalTable: "Cropping",
                        principalColumn: "CroppingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CroppingFarm_Farms_FarmsFarmId",
                        column: x => x.FarmsFarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CroppingFarm_FarmsFarmId",
                table: "CroppingFarm",
                column: "FarmsFarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CroppingFarm");

            migrationBuilder.DropTable(
                name: "Cropping");
        }
    }
}
