using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NHNT.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "tbl_user",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "tbl_user",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<bool>(
                name: "is_disable",
                table: "tbl_user",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "tbl_user",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "tbl_user",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.CreateTable(
                name: "tbl_department_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    discription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_department_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    room_area = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "PENDING"),
                    discription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    is_available = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "FK_department_tbl_department_group_group_id",
                        column: x => x.group_id,
                        principalTable: "tbl_department_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_department_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    department_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_image", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_image_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_phone",
                table: "tbl_user",
                column: "phone",
                unique: true,
                filter: "[phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_department_group_id",
                table: "department",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_user_id",
                table: "department",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_image_department_id",
                table: "tbl_image",
                column: "department_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_image");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "tbl_department_group");

            migrationBuilder.DropIndex(
                name: "IX_tbl_user_phone",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "full_name",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "is_disable",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "tbl_user");
        }
    }
}
