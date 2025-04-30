using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class updated_data_urls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://example.com/vegan-juice.jpg");

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 8, "https://www.bing.com/th/id/OIP.Gsl2sxyGt020l_KzrKqEHAHaFE?w=273&h=211&c=8&rs=1&qlt=90&o=6&dpr=2&pid=3.1&rm=2", "Peach Oolong Tea", 3.25m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);
        }
    }
}
