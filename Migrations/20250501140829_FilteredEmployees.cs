using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class FilteredEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE GetFilteredEmployees 
            @Id INT = NULL,
            @Name NVARCHAR(MAX) = NULL,
            @Position NVARCHAR(MAX) = NULL,
            @Salary DECIMAL(18, 2) = NULL,
            @Shift NVARCHAR(MAX) = NULL,
            @SortColumn NVARCHAR(MAX) = NULL,
            @SortDirection NVARCHAR(MAX) = NULL

            AS
            BEGIN 
            SET NOCOUNT ON;

        

            SELECT * FROM Employees 
            
            WHERE (@Id IS NULL OR Id = @Id) AND
                  (@Name IS NULL OR Name LIKE '%' + @Name + '%') AND
                  (@Position IS NULL OR Position LIKE '%' + @Position + '%') AND
                  (@Salary IS NULL OR Salary = @Salary) AND
                  (@Shift IS NULL OR Shift LIKE '%' + @Shift + '%')

            END
            ");

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

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetFilteredEmployees");
            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "Classic Milk Tea", 3.50m },
                    { 2, null, "Taro Milk Tea", 4.00m },
                    { 3, null, "Matcha Latte", 4.50m },
                    { 4, null, "Mango Smoothie", 5.00m },
                    { 5, null, "Strawberry Lemonade", 3.75m },
                    { 6, null, "The blood of my enemies", 4.25m }
                });
        }
    }
}
