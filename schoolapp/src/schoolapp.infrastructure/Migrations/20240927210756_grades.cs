using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class grades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_class_rooms_grade_id",
                schema: "school",
                table: "class_rooms",
                column: "grade_id");

            migrationBuilder.AddForeignKey(
                name: "fk_class_rooms_grades_grade_id",
                schema: "school",
                table: "class_rooms",
                column: "grade_id",
                principalSchema: "school",
                principalTable: "grades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_class_rooms_grades_grade_id",
                schema: "school",
                table: "class_rooms");

            migrationBuilder.DropIndex(
                name: "ix_class_rooms_grade_id",
                schema: "school",
                table: "class_rooms");

        }
    }
}
