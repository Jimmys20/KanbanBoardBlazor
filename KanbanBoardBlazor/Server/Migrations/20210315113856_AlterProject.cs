using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoardBlazor.Server.Migrations
{
    public partial class AlterProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                schema: "ISSUE_TRACKER",
                table: "PROJECT",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IS_OPEN",
                schema: "ISSUE_TRACKER",
                table: "PROJECT",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                schema: "ISSUE_TRACKER",
                table: "PROJECT");

            migrationBuilder.DropColumn(
                name: "IS_OPEN",
                schema: "ISSUE_TRACKER",
                table: "PROJECT");
        }
    }
}
