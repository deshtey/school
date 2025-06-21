using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class salutation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salutation",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "salutation",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "salutation",
                schema: "school",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "salutation",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salutation",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "salutation",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "salutation",
                schema: "school",
                table: "students");

            migrationBuilder.DropColumn(
                name: "salutation",
                schema: "school",
                table: "parents");
        }
    }
}
