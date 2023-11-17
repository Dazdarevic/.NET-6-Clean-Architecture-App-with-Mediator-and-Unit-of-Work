using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Napredne_baze_podataka_API.Migrations
{
    /// <inheritdoc />
    public partial class baaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sponsors_SponsorID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SponsorID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SponsorID",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SponsorID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SponsorID",
                table: "Products",
                column: "SponsorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sponsors_SponsorID",
                table: "Products",
                column: "SponsorID",
                principalTable: "Sponsors",
                principalColumn: "ID");
        }
    }
}
