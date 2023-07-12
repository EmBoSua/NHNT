using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NHNT.Migrations
{
    public partial class intit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    discription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_refresh_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    jwt_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_revoked = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    issued_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expired_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_refresh_token", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_refresh_token_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_role",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_role", x => new { x.role_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_tbl_user_role_tbl_role_role_id",
                        column: x => x.role_id,
                        principalTable: "tbl_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_user_role_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_refresh_token_user_id",
                table: "tbl_refresh_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_name",
                table: "tbl_role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_email",
                table: "tbl_user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_username",
                table: "tbl_user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_role_user_id",
                table: "tbl_user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_refresh_token");

            migrationBuilder.DropTable(
                name: "tbl_user_role");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
