using Microsoft.EntityFrameworkCore.Migrations;

namespace KanbanBoardBlazor.Server.Migrations
{
    public partial class AlterIssueDescriptionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                type: "NCLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NCLOB",
                oldNullable: true);
        }
    }
}
