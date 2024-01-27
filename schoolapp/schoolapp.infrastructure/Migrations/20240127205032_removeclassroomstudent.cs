using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeclassroomstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassRooms_ClassRoomId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ClassRoomStudents");

            migrationBuilder.RenameColumn(
                name: "ClassRoomId",
                table: "Students",
                newName: "ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassRoomId",
                table: "Students",
                newName: "IX_Students_ClassroomId");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassRooms_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassRooms_ClassroomId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassroomId",
                table: "Students",
                newName: "ClassRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                newName: "IX_Students_ClassRoomId");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "ClassRoomStudents",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomStudents", x => x.ClassRoomId);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudents_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudents_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudents_GradeId",
                table: "ClassRoomStudents",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudents_SchoolId",
                table: "ClassRoomStudents",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudents_StudentId",
                table: "ClassRoomStudents",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassRooms_ClassRoomId",
                table: "Students",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "ClassRoomId");
        }
    }
}
