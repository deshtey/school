using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class school_settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "school_settings",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parent_school_id = table.Column<int>(type: "integer", nullable: false),
                    school_type = table.Column<int>(type: "integer", nullable: false),
                    use_single_name = table.Column<bool>(type: "boolean", nullable: false),
                    is_group_of_schools = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_school_settings_schools_parent_school_id",
                        column: x => x.parent_school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_school_settings_parent_school_id",
                schema: "school",
                table: "school_settings",
                column: "parent_school_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "school_settings",
                schema: "school");
        }
    }
}
