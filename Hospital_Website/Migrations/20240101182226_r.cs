using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Website.Migrations
{
    public partial class r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hastane_ilce_ilID",
                table: "hastane");

            migrationBuilder.DropIndex(
                name: "IX_hastane_ilID",
                table: "hastane");

            migrationBuilder.DropColumn(
                name: "ilID",
                table: "hastane");

            migrationBuilder.CreateIndex(
                name: "IX_hastane_ilceID",
                table: "hastane",
                column: "ilceID");

            migrationBuilder.AddForeignKey(
                name: "FK_hastane_ilce_ilceID",
                table: "hastane",
                column: "ilceID",
                principalTable: "ilce",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hastane_ilce_ilceID",
                table: "hastane");

            migrationBuilder.DropIndex(
                name: "IX_hastane_ilceID",
                table: "hastane");

            migrationBuilder.AddColumn<int>(
                name: "ilID",
                table: "hastane",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_hastane_ilID",
                table: "hastane",
                column: "ilID");

            migrationBuilder.AddForeignKey(
                name: "FK_hastane_ilce_ilID",
                table: "hastane",
                column: "ilID",
                principalTable: "ilce",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
