using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class student_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_ClassRooms_StudentClassClassRoomId",
                schema: "school",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_StudentClassClassRoomId",
                schema: "school",
                table: "students");

            migrationBuilder.DropColumn(
                name: "StudentClassClassRoomId",
                schema: "school",
                table: "students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentClassClassRoomId",
                schema: "school",
                table: "students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_StudentClassClassRoomId",
                schema: "school",
                table: "students",
                column: "StudentClassClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_ClassRooms_StudentClassClassRoomId",
                schema: "school",
                table: "students",
                column: "StudentClassClassRoomId",
                principalSchema: "school",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId");
        }
    }
}
