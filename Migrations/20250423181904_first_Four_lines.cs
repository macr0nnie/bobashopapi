using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class first_Four_lines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Position",
                value: "  Lawyer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Position",
                value: "Lawyer");
        }
    }
}
