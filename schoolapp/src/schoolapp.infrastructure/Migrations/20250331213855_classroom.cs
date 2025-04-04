using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class classroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "people",
                table: "students");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "school",
                table: "schools");

            migrationBuilder.DropColumn(
                name: "active",
                schema: "school",
                table: "parents");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "school",
                table: "teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "school",
                table: "support_staffs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "people",
                table: "students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "school",
                table: "schools",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "school",
                table: "parents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                schema: "school",
                table: "class_rooms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms",
                column: "teacher_id",
                principalSchema: "school",
                principalTable: "teachers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "school",
                table: "schools");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "school",
                table: "teachers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "school",
                table: "support_staffs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "people",
                table: "students",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "people",
                table: "students",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "school",
                table: "schools",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "school",
                table: "parents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                schema: "school",
                table: "class_rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms",
                column: "teacher_id",
                principalSchema: "school",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
