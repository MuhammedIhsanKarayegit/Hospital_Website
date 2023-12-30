using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocamanHastanesi.Migrations
{
    public partial class hastaneProje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hasta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hasta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "il",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_il", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ilce",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilce", x => x.id);
                    table.ForeignKey(
                        name: "FK_ilce_il_ilID",
                        column: x => x.ilID,
                        principalTable: "il",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hastane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hastane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hastane_ilce_ilceID",
                        column: x => x.ilceID,
                        principalTable: "ilce",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "poliklinik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poliklinik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_poliklinik_hastane_hastaneId",
                        column: x => x.hastaneId,
                        principalTable: "hastane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doktor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poliklinikid = table.Column<int>(type: "int", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doktor", x => x.id);
                    table.ForeignKey(
                        name: "FK_doktor_poliklinik_poliklinikid",
                        column: x => x.poliklinikid,
                        principalTable: "poliklinik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hastaID = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    doktorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_randevu_doktor_doktorID",
                        column: x => x.doktorID,
                        principalTable: "doktor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_randevu_hasta_hastaID",
                        column: x => x.hastaID,
                        principalTable: "hasta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doktor_poliklinikid",
                table: "doktor",
                column: "poliklinikid");

            migrationBuilder.CreateIndex(
                name: "IX_hastane_ilceID",
                table: "hastane",
                column: "ilceID");

            migrationBuilder.CreateIndex(
                name: "IX_ilce_ilID",
                table: "ilce",
                column: "ilID");

            migrationBuilder.CreateIndex(
                name: "IX_poliklinik_hastaneId",
                table: "poliklinik",
                column: "hastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_randevu_doktorID",
                table: "randevu",
                column: "doktorID");

            migrationBuilder.CreateIndex(
                name: "IX_randevu_hastaID",
                table: "randevu",
                column: "hastaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "randevu");

            migrationBuilder.DropTable(
                name: "doktor");

            migrationBuilder.DropTable(
                name: "hasta");

            migrationBuilder.DropTable(
                name: "poliklinik");

            migrationBuilder.DropTable(
                name: "hastane");

            migrationBuilder.DropTable(
                name: "ilce");

            migrationBuilder.DropTable(
                name: "il");
        }
    }
}
