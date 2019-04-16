using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Suplier = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusQCs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusQCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    TraceID = table.Column<string>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    MaterialID = table.Column<string>(nullable: true),
                    StatusQCID = table.Column<int>(nullable: false),
                    Lot = table.Column<string>(nullable: true),
                    ComingDate = table.Column<DateTime>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(nullable: false),
                    QTY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.TraceID);
                    table.ForeignKey(
                        name: "FK_Stoks_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stoks_Materials_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Materials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stoks_StatusQCs_StatusQCID",
                        column: x => x.StatusQCID,
                        principalTable: "StatusQCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_LocationID",
                table: "Stoks",
                column: "LocationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_MaterialID",
                table: "Stoks",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_StatusQCID",
                table: "Stoks",
                column: "StatusQCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stoks");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "StatusQCs");
        }
    }
}
