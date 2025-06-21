using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullable_teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "teacher_id",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "teacher_id",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
