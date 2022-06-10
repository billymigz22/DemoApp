using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    public partial class Farmcropping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CroppingFarm_Cropping_CroppingsCroppingId",
                table: "CroppingFarm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cropping",
                table: "Cropping");

            migrationBuilder.RenameTable(
                name: "Cropping",
                newName: "Croppings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Croppings",
                table: "Croppings",
                column: "CroppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CroppingFarm_Croppings_CroppingsCroppingId",
                table: "CroppingFarm",
                column: "CroppingsCroppingId",
                principalTable: "Croppings",
                principalColumn: "CroppingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CroppingFarm_Croppings_CroppingsCroppingId",
                table: "CroppingFarm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Croppings",
                table: "Croppings");

            migrationBuilder.RenameTable(
                name: "Croppings",
                newName: "Cropping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cropping",
                table: "Cropping",
                column: "CroppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CroppingFarm_Cropping_CroppingsCroppingId",
                table: "CroppingFarm",
                column: "CroppingsCroppingId",
                principalTable: "Cropping",
                principalColumn: "CroppingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
