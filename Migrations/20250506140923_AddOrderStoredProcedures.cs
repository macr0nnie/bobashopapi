using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DrinkId",
                table: "OrderItems",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            // Add stored procedures for orders
            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.GetAllOrders
AS
BEGIN
    SELECT Id, CustomerName, TotalAmount, OrderDate
    FROM Orders
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.GetOrderById
    @OrderId INT
AS
BEGIN
    SELECT Id, CustomerName, TotalAmount, OrderDate
    FROM Orders
    WHERE Id = @OrderId
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.AddOrder
    @CustomerName NVARCHAR(MAX),
    @TotalAmount DECIMAL(18,2),
    @OrderDate DATETIME
AS
BEGIN
    INSERT INTO Orders (CustomerName, TotalAmount, OrderDate)
    VALUES (@CustomerName, @TotalAmount, @OrderDate)
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.UpdateOrder
    @OrderId INT,
    @CustomerName NVARCHAR(MAX),
    @TotalAmount DECIMAL(18,2),
    @OrderDate DATETIME
AS
BEGIN
    UPDATE Orders
    SET CustomerName = @CustomerName,
        TotalAmount = @TotalAmount,
        OrderDate = @OrderDate
    WHERE Id = @OrderId
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.DeleteOrder
    @OrderId INT
AS
BEGIN
    DELETE FROM Orders
    WHERE Id = @OrderId
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.GetFilteredOrders
    @Filter NVARCHAR(MAX)
AS
BEGIN
    SELECT Id, CustomerName, TotalAmount, OrderDate
    FROM Orders
    WHERE CustomerName LIKE '%' + @Filter + '%'
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.GetOrderDetails
    @OrderId INT
AS
BEGIN
    SELECT Id, CustomerName, TotalAmount, OrderDate
    FROM Orders
    WHERE Id = @OrderId
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.GetAllOrders");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.GetOrderById");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.AddOrder");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.UpdateOrder");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.DeleteOrder");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.GetFilteredOrders");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.GetOrderDetails");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Orders");
        }
    }
}
