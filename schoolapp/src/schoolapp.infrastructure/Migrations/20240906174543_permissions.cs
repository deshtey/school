using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                schema: "school",
                table: "role_permissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_permission",
                schema: "school",
                table: "permission");

            migrationBuilder.RenameTable(
                name: "permission",
                schema: "school",
                newName: "permissions",
                newSchema: "school");

            migrationBuilder.AddPrimaryKey(
                name: "pk_permissions",
                schema: "school",
                table: "permissions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permissions_permission_id",
                schema: "school",
                table: "role_permissions",
                column: "permission_id",
                principalSchema: "school",
                principalTable: "permissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_role_permissions_permissions_permission_id",
                schema: "school",
                table: "role_permissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_permissions",
                schema: "school",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "permissions",
                schema: "school",
                newName: "permission",
                newSchema: "school");

            migrationBuilder.AddPrimaryKey(
                name: "pk_permission",
                schema: "school",
                table: "permission",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_role_permissions_permission_permission_id",
                schema: "school",
                table: "role_permissions",
                column: "permission_id",
                principalSchema: "school",
                principalTable: "permission",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
