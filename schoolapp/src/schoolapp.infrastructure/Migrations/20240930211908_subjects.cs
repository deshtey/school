using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class subjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "academics");

            migrationBuilder.EnsureSchema(
                name: "people");

            migrationBuilder.RenameTable(
                name: "students",
                schema: "school",
                newName: "students",
                newSchema: "people");

            migrationBuilder.CreateTable(
                name: "school_subjects",
                schema: "academics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    desc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_school_subjects_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classroom_subjects",
                schema: "academics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    class_room_id = table.Column<int>(type: "integer", nullable: false),
                    school_subject_id = table.Column<int>(type: "integer", nullable: false),
                    elective = table.Column<bool>(type: "boolean", nullable: false),
                    subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classroom_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_classroom_subjects_class_rooms_class_room_id",
                        column: x => x.class_room_id,
                        principalSchema: "school",
                        principalTable: "class_rooms",
                        principalColumn: "class_room_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_classroom_subjects_school_subjects_school_subject_id",
                        column: x => x.school_subject_id,
                        principalSchema: "academics",
                        principalTable: "school_subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student_subjects",
                schema: "academics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    subject_id = table.Column<int>(type: "integer", nullable: false),
                    classroom_subject_id = table.Column<int>(type: "integer", nullable: false),
                    subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    elective = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_subjects_class_room_subjects_classroom_subject_id",
                        column: x => x.classroom_subject_id,
                        principalSchema: "academics",
                        principalTable: "classroom_subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_student_subjects_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "people",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_classroom_subjects_class_room_id",
                schema: "academics",
                table: "classroom_subjects",
                column: "class_room_id");

            migrationBuilder.CreateIndex(
                name: "ix_classroom_subjects_school_subject_id",
                schema: "academics",
                table: "classroom_subjects",
                column: "school_subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_school_subjects_school_id",
                schema: "academics",
                table: "school_subjects",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subjects_classroom_subject_id",
                schema: "academics",
                table: "student_subjects",
                column: "classroom_subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subjects_student_id",
                schema: "academics",
                table: "student_subjects",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_subjects",
                schema: "academics");

            migrationBuilder.DropTable(
                name: "classroom_subjects",
                schema: "academics");

            migrationBuilder.DropTable(
                name: "school_subjects",
                schema: "academics");

            migrationBuilder.RenameTable(
                name: "students",
                schema: "people",
                newName: "students",
                newSchema: "school");
        }
    }
}
