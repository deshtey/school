using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations.SchoolDb
{
    /// <inheritdoc />
    public partial class academic_terms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_students_grades_current_grade_id",
                schema: "people",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "current_grade_id",
                schema: "people",
                table: "students",
                newName: "current_class_id");

            migrationBuilder.RenameIndex(
                name: "ix_students_current_grade_id",
                schema: "people",
                table: "students",
                newName: "ix_students_current_class_id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "start_date",
                schema: "school",
                table: "academic_years",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "end_date",
                schema: "school",
                table: "academic_years",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "school_id",
                schema: "school",
                table: "academic_years",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "start_date",
                schema: "school",
                table: "academic_terms",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "end_date",
                schema: "school",
                table: "academic_terms",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "fk_students_class_rooms_current_class_id",
                schema: "people",
                table: "students",
                column: "current_class_id",
                principalSchema: "school",
                principalTable: "class_rooms",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_students_class_rooms_current_class_id",
                schema: "people",
                table: "students");

            migrationBuilder.DropColumn(
                name: "school_id",
                schema: "school",
                table: "academic_years");

            migrationBuilder.RenameColumn(
                name: "current_class_id",
                schema: "people",
                table: "students",
                newName: "current_grade_id");

            migrationBuilder.RenameIndex(
                name: "ix_students_current_class_id",
                schema: "people",
                table: "students",
                newName: "ix_students_current_grade_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "school",
                table: "academic_years",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "school",
                table: "academic_years",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "school",
                table: "academic_terms",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "school",
                table: "academic_terms",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "fk_students_grades_current_grade_id",
                schema: "people",
                table: "students",
                column: "current_grade_id",
                principalSchema: "school",
                principalTable: "grades",
                principalColumn: "id");
        }
    }
}
