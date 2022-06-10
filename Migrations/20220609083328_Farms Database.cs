using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    public partial class FarmsDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Farmers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hectare = table.Column<int>(type: "int", nullable: false),
                    TenurialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmId);
                    table.ForeignKey(
                        name: "FK_Farms_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
