using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class departments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_teachers_department_department_id",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "ix_teachers_department_id",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "department_id",
                schema: "school",
                table: "teachers");

            migrationBuilder.CreateTable(
                name: "department_support_staff",
                schema: "school",
                columns: table => new
                {
                    departments_id = table.Column<int>(type: "integer", nullable: false),
                    staff_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_department_support_staff", x => new { x.departments_id, x.staff_id });
                    table.ForeignKey(
                        name: "fk_department_support_staff_department_departments_id",
                        column: x => x.departments_id,
                        principalSchema: "school",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_support_staff_staff_staff_id",
                        column: x => x.staff_id,
                        principalSchema: "school",
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "department_teacher",
                schema: "school",
                columns: table => new
                {
                    departments_id = table.Column<int>(type: "integer", nullable: false),
                    teachers_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_department_teacher", x => new { x.departments_id, x.teachers_id });
                    table.ForeignKey(
                        name: "fk_department_teacher_department_departments_id",
                        column: x => x.departments_id,
                        principalSchema: "school",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_teacher_teachers_teachers_id",
                        column: x => x.teachers_id,
                        principalSchema: "school",
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_department_support_staff_staff_id",
                schema: "school",
                table: "department_support_staff",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "ix_department_teacher_teachers_id",
                schema: "school",
                table: "department_teacher",
                column: "teachers_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "department_support_staff",
                schema: "school");

            migrationBuilder.DropTable(
                name: "department_teacher",
                schema: "school");

            migrationBuilder.AddColumn<int>(
                name: "department_id",
                schema: "school",
                table: "teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_teachers_department_id",
                schema: "school",
                table: "teachers",
                column: "department_id");

            migrationBuilder.AddForeignKey(
                name: "fk_teachers_department_department_id",
                schema: "school",
                table: "teachers",
                column: "department_id",
                principalSchema: "school",
                principalTable: "department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
