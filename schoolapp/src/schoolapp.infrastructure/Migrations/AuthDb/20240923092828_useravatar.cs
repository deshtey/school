using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class useravatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avatar",
                schema: "auth",
                table: "aspnetusers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                schema: "auth",
                table: "aspnetusers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                schema: "auth",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "country_code",
                schema: "auth",
                table: "aspnetusers");
        }
    }
}
