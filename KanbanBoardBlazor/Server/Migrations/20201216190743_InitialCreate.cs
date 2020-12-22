using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace KanbanBoardBlazor.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ISSUE_TRACKER");

            migrationBuilder.CreateTable(
                name: "APP_USER",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    USER_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true),
                    LAST_NAME = table.Column<string>(nullable: true),
                    FIRST_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APP_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECT",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    PROJECT_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECT", x => x.PROJECT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TAG",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    TAG_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TEXT = table.Column<string>(nullable: true),
                    CSS_CLASS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.TAG_ID);
                });

            migrationBuilder.CreateTable(
                name: "STAGE",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    STAGE_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    POSITION = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    COLOR = table.Column<string>(nullable: true),
                    LIMIT = table.Column<int>(nullable: true),
                    PROJECT_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAGE", x => x.STAGE_ID);
                    table.ForeignKey(
                        name: "FK_STAGE_PROJECT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "PROJECT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISSUE",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    ISSUE_ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DEADLINE = table.Column<DateTime>(nullable: true),
                    PRIORITY = table.Column<int>(nullable: false),
                    CREATED_AT = table.Column<DateTime>(nullable: false),
                    UPDATED_AT = table.Column<DateTime>(nullable: true),
                    IS_OPEN = table.Column<bool>(nullable: false),
                    STAGE_ID = table.Column<long>(nullable: true),
                    PROJECT_ID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISSUE", x => x.ISSUE_ID);
                    table.ForeignKey(
                        name: "FK_ISSUE_PROJECT_PROJECT_ID",
                        column: x => x.PROJECT_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "PROJECT",
                        principalColumn: "PROJECT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ISSUE_STAGE_STAGE_ID",
                        column: x => x.STAGE_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "STAGE",
                        principalColumn: "STAGE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASSIGNMENT",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    ISSUE_ID = table.Column<long>(nullable: false),
                    USER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSIGNMENT", x => new { x.ISSUE_ID, x.USER_ID });
                    table.ForeignKey(
                        name: "FK_ASSIGNMENT_ISSUE_ISSUE_ID",
                        column: x => x.ISSUE_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "ISSUE",
                        principalColumn: "ISSUE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ASSIGNMENT_APP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "APP_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISSUE_CUSTOMER",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    ISSUE_ID = table.Column<long>(nullable: false),
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISSUE_CUSTOMER", x => new { x.ISSUE_ID, x.CUSTOMER_ID });
                    table.ForeignKey(
                        name: "FK_ISSUE_CUSTOMER_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ISSUE_CUSTOMER_ISSUE_ISSUE_ID",
                        column: x => x.ISSUE_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "ISSUE",
                        principalColumn: "ISSUE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISSUE_TAG",
                schema: "ISSUE_TRACKER",
                columns: table => new
                {
                    ISSUE_ID = table.Column<long>(nullable: false),
                    TAG_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISSUE_TAG", x => new { x.ISSUE_ID, x.TAG_ID });
                    table.ForeignKey(
                        name: "FK_ISSUE_TAG_ISSUE_ISSUE_ID",
                        column: x => x.ISSUE_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "ISSUE",
                        principalColumn: "ISSUE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ISSUE_TAG_TAG_TAG_ID",
                        column: x => x.TAG_ID,
                        principalSchema: "ISSUE_TRACKER",
                        principalTable: "TAG",
                        principalColumn: "TAG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSIGNMENT_USER_ID",
                schema: "ISSUE_TRACKER",
                table: "ASSIGNMENT",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ISSUE_PROJECT_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                column: "PROJECT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ISSUE_STAGE_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE",
                column: "STAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ISSUE_CUSTOMER_CUSTOMER_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE_CUSTOMER",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ISSUE_TAG_TAG_ID",
                schema: "ISSUE_TRACKER",
                table: "ISSUE_TAG",
                column: "TAG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STAGE_PROJECT_ID",
                schema: "ISSUE_TRACKER",
                table: "STAGE",
                column: "PROJECT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSIGNMENT",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "ISSUE_CUSTOMER",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "ISSUE_TAG",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "APP_USER",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "CUSTOMER",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "ISSUE",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "TAG",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "STAGE",
                schema: "ISSUE_TRACKER");

            migrationBuilder.DropTable(
                name: "PROJECT",
                schema: "ISSUE_TRACKER");
        }
    }
}
