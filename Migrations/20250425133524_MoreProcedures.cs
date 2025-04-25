using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class MoreProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE get_employee_by_id
                    @Id INT
                AS
                BEGIN
                    SELECT * FROM Employees WHERE Id = @Id
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE add_employee
                    @Name NVARCHAR(100),
                    @Position NVARCHAR(100),
                    @Salary DECIMAL(18, 2),
                    @Shift NVARCHAR(50)
                AS
                BEGIN
                    INSERT INTO Employees (Name, Position, Salary, Shift)
                    VALUES (@Name, @Position, @Salary, @Shift)
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE update_employee
                    @Id INT,
                    @Name NVARCHAR(100),
                    @Position NVARCHAR(100),
                    @Salary DECIMAL(18, 2),
                    @Shift NVARCHAR(50)
                AS
                BEGIN
                    UPDATE Employees
                    SET Name = @Name, Position = @Position, Salary = @Salary, Shift = @Shift
                    WHERE Id = @Id
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE delete_employee
                    @Id INT
                AS
                BEGIN
                    DELETE FROM Employees WHERE Id = @Id
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE get_all_drinks
                AS
                BEGIN
                    SELECT * FROM Drinks
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE get_drink_by_id
                    @Id INT
                AS
                BEGIN
                    SELECT * FROM Drinks WHERE Id = @Id
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE add_drink
                    @Name NVARCHAR(100),
                    @Price DECIMAL(18, 2)
                AS
                BEGIN
                    INSERT INTO Drinks (Name, Price)
                    VALUES (@Name, @Price)
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE update_drink
                    @Id INT,
                    @Name NVARCHAR(100),
                    @Price DECIMAL(18, 2)
                AS
                BEGIN
                    UPDATE Drinks
                    SET Name = @Name, Price = @Price
                    WHERE Id = @Id
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE delete_drink
                    @Id INT
                AS
                BEGIN
                    DELETE FROM Drinks WHERE Id = @Id
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            // Drop stored procedures
     
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS get_employee_by_id");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS add_employee");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS update_employee");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS delete_employee");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS get_all_drinks");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS get_drink_by_id");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS add_drink");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS update_drink");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS delete_drink");
        }
    }
}