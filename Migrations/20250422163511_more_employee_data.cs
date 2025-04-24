using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class more_employee_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Position", "Salary", "Shift" },
                values: new object[,]
                {
                    { 1, "John Doe", "Manager", 50000m, "Morning" },
                    { 2, "Jane Smith", "Barista", 30000m, "Afternoon" },
                    { 3, "Sam Brown", "Cashier", 25000m, "Evening" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
