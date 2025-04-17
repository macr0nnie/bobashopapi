using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class adding_new_stuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Position", "Salary", "Shift" },
                values: new object[,]
                {
                    { 6, "Daisy White", "Barista", 32000m, "Morning" },
                    { 7, "Shelly Jarskey", "Lead Scientist", 5500000m, "Morning" },
                    { 8, "Creature Jarskey", "Sad Intern", 10m, "Graveyard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
