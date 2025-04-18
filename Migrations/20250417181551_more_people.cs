using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class more_people : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 6, "The blood of my enemies", 4.25m },
                    { 7, "Vegan Juice", 20.8m }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Jojo Siwa", "Matcha Man", 10000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Bella", "Lawyer", 500000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Grayce Johnson", "Taster", 250000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Cindy Cindy'sLastName");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "General Trab", "HR", 400000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Position", "Salary", "Shift" },
                values: new object[] { "Oliver JFK", "RadStreamer", 320000m, "Reasonable Hours" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Shelly Jarsky");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Creature Jarsky");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Position", "Salary", "Shift" },
                values: new object[,]
                {
                    { 9, "Numi Toffe", "Stay at Home Daughter", 5000m, "24/7" },
                    { 10, "Tia", "Writer", 1000000m, "Evening" },
                    { 11, "Lexi", "Vegan", 2000000m, "Morning" },
                    { 12, "Jennifer Kanna", "Estition", 2000000m, "Morning" },
                    { 13, "Josh", "Kanna's Assistant/Stay at Home Husband", 20m, "Morning" },
                    { 14, "Yoni ", "Streamer", 200000000m, "Night" },
                    { 15, "Lev", "Acedemic Weapon", 1000m, "Morning" },
                    { 16, "Lochnessa", "Manager", 100000m, "Morning" },
                    { 17, "Zoe Catluv7", "Marine Biologist", 100000m, "Morning" },
                    { 18, "Esme", "Japanese", 100000m, "Morning" },
                    { 19, "Barbie", "Being Hot", 10000000000m, "Morning" },
                    { 20, "Megan", "Stuff", 100000m, "Morning" },
                    { 21, "Alf", "Boba Maker", 50m, "Graveyard" },
                    { 22, "Riley Catluv7", "Boba Music/Zoe's Pet", 30m, "Graveyard" },
                    { 23, "Avery", "Professor", 300000m, "Morning" },
                    { 24, "Megan Catluv7", "Boba Music/Zoe's Pet", 30m, "Graveyard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "John Doe", "Barista", 30000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Jane Smith", "Manager", 50000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Alice Johnson", "Cashier", 25000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Bob Brown");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Position", "Salary" },
                values: new object[] { "Charlie Green", "Supervisor", 40000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Position", "Salary", "Shift" },
                values: new object[] { "Daisy White", "Barista", 32000m, "Morning" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Shelly Jarskey");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Creature Jarskey");
        }
    }
}
