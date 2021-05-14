using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPI.Migrations.ProblemDetails
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProblemDetails",
                columns: table => new
                {
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    instance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemDetails");
        }
    }
}
