using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace KanbanBoardBlazor.Server.Migrations
{
    public partial class AddApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "APPLICATION",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    APPLICATION_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATION", x => x.APPLICATION_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ISSUE_APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                column: "APPLICATION_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ISSUE_APPLICATION_APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                column: "APPLICATION_ID",
                principalSchema: "ISSUE_TRACKER",
                principalTable: "APPLICATION",
                principalColumn: "APPLICATION_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISSUE_APPLICATION_APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE");

            migrationBuilder.DropTable(
                name: "APPLICATION",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropIndex(
                name: "IX_ISSUE_APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE");

            migrationBuilder.DropColumn(
                name: "APPLICATION_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE");
        }
    }
}
