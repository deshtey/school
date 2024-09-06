using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class staffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "staff_id",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.AlterColumn<string>(
                name: "teacher_id",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "designation",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "department_id",
                schema: "school",
                table: "support_staffs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "staff_number",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "staff_number",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                schema: "school",
                table: "teachers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "designation",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "department_id",
                schema: "school",
                table: "support_staffs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "staff_id",
                schema: "school",
                table: "support_staffs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
