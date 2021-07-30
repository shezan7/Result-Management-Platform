using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultSystem.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Roll = table.Column<int>(type: "number", nullable: false),
                    Semester = table.Column<int>(type: "number", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Mid = table.Column<double>(type: "REAL", nullable: false),
                    Quiz = table.Column<double>(type: "number", nullable: false),
                    Lab = table.Column<double>(type: "number", nullable: false),
                    Final = table.Column<double>(type: "number", nullable: false),
                    CourseResult = table.Column<double>(type: "number", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Roll = table.Column<string>(type: "number", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Batch = table.Column<int>(type: "number", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Result = table.Column<double>(type: "number", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
