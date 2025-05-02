using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BobaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class rename_stored_procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    
          migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE get_filtered_employees 
            @Id INT = NULL,
            @Name NVARCHAR(MAX) = NULL,
            @Position NVARCHAR(MAX) = NULL,
            @Salary DECIMAL(18, 2) = NULL,
            @Shift NVARCHAR(MAX) = NULL,
            @SortColumn NVARCHAR(MAX) = NULL,
            @SortDirection NVARCHAR(MAX) = NULL,
            @MinSalary DECIMAL(18, 2) = NULL,
            @MaxSalary DECIMAL(18, 2) = NULL

            AS
            BEGIN 
            SET NOCOUNT ON;
            SELECT * FROM Employees 
            
            WHERE (@Id IS NULL OR Id = @Id) AND
                  (@Name IS NULL OR Name LIKE '%' + @Name + '%') AND
                  (@Position IS NULL OR Position LIKE '%' + @Position + '%') AND
                  (@Salary IS NULL OR Salary = @Salary) AND
                  (@Shift IS NULL OR Shift LIKE '%' + @Shift + '%') AND
                  (@MinSalary IS NULL OR Salary >= @MinSalary) AND
                  (@MaxSalary IS NULL OR Salary <= @MaxSalary)

            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql("DROP PROCEDURE GetFilteredEmployees");
                migrationBuilder.Sql("DROP PROCEDURE get_filtered_employees");
        }
    }
}
