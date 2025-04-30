using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class AddImageURLDrinkModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
        CREATE OR ALTER PROCEDURE AddDrink
            @Name NVARCHAR(MAX),
            @ImageUrl NVARCHAR(MAX),
            @Price DECIMAL(18, 2)
        AS
        BEGIN
            INSERT INTO Drinks (Name, ImageUrl, Price)
            VALUES (@Name, @ImageUrl, @Price);
        END
    ");
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Drinks");

            migrationBuilder.Sql(@"
        CREATE OR ALTER PROCEDURE AddDrink
            @Name NVARCHAR(MAX),
            @ImageUrl NVARCHAR(MAX),
            @Price DECIMAL(18, 2)
        AS
        BEGIN
            INSERT INTO Drinks (Name, ImageUrl, Price)
            VALUES (@Name, @ImageUrl, @Price);
        END
    ");
        }
    }
}
