using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace payrolll.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeMasterData_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employeemasterdata",
                columns: table => new
                {
                    Empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WA_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WA_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WA_Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WA_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WA_Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HA_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HA_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HA_Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HA_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HA_Religion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeemasterdata", x => x.Empid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeemasterdata");
        }
    }
}
