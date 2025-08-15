using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations.SchoolDb
{
    /// <inheritdoc />
    public partial class studentclassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_students_class_rooms_current_class_id",
                schema: "people",
                table: "students");

            migrationBuilder.DropIndex(
                name: "ix_students_current_class_id",
                schema: "people",
                table: "students");

            migrationBuilder.DropColumn(
                name: "current_class_id",
                schema: "people",
                table: "students");

            migrationBuilder.DropColumn(
                name: "student_id",
                schema: "school",
                table: "parents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "current_class_id",
                schema: "people",
                table: "students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                schema: "school",
                table: "parents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_students_current_class_id",
                schema: "people",
                table: "students",
                column: "current_class_id");

            migrationBuilder.AddForeignKey(
                name: "fk_students_class_rooms_current_class_id",
                schema: "people",
                table: "students",
                column: "current_class_id",
                principalSchema: "school",
                principalTable: "class_rooms",
                principalColumn: "id");
        }
    }
}
