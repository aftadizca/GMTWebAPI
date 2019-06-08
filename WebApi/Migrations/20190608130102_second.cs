using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stoks_LocationID",
                table: "Stoks");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_LocationID",
                table: "Stoks",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stoks_LocationID",
                table: "Stoks");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_LocationID",
                table: "Stoks",
                column: "LocationID",
                unique: true,
                filter: "[LocationID] IS NOT NULL");
        }
    }
}
