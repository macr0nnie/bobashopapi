using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic Milk Tea", 3.50m },
                    { 2, "Taro Milk Tea", 4.00m },
                    { 3, "Matcha Latte", 4.50m },
                    { 4, "Mango Smoothie", 5.00m },
                    { 5, "Strawberry Lemonade", 3.75m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
