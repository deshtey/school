using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_department_support_staff_department_departments_id",
                schema: "school",
                table: "department_support_staff");

            migrationBuilder.DropForeignKey(
                name: "fk_department_support_staff_staff_staff_id",
                schema: "school",
                table: "department_support_staff");

            migrationBuilder.DropForeignKey(
                name: "fk_department_teacher_department_departments_id",
                schema: "school",
                table: "department_teacher");

            migrationBuilder.DropForeignKey(
                name: "fk_staff_schools_school_id",
                schema: "school",
                table: "staff");

            migrationBuilder.DropPrimaryKey(
                name: "pk_staff",
                schema: "school",
                table: "staff");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department",
                schema: "school",
                table: "department");

            migrationBuilder.RenameTable(
                name: "staff",
                schema: "school",
                newName: "support_staffs",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "department",
                schema: "school",
                newName: "departments",
                newSchema: "school");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "school",
                table: "teachers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "region",
                schema: "school",
                table: "students",
                newName: "other_names");

            migrationBuilder.RenameColumn(
                name: "primary_phone",
                schema: "school",
                table: "students",
                newName: "national_id");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "school",
                table: "students",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "school",
                table: "parents",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "school",
                table: "support_staffs",
                newName: "last_name");

            migrationBuilder.RenameIndex(
                name: "ix_staff_school_id",
                schema: "school",
                table: "support_staffs",
                newName: "ix_support_staffs_school_id");

            migrationBuilder.AddColumn<string>(
                name: "city",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "national_id",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "other_names",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                schema: "school",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "school",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "other_names",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                schema: "school",
                table: "parents",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                schema: "school",
                table: "class_rooms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "city",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "national_id",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "other_names",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                schema: "school",
                table: "support_staffs",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_support_staffs",
                schema: "school",
                table: "support_staffs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_departments",
                schema: "school",
                table: "departments",
                column: "id");

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    desc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_permissions_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "school",
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_permission_id",
                schema: "school",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms",
                column: "teacher_id",
                principalSchema: "school",
                principalTable: "teachers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_department_support_staff_departments_departments_id",
                schema: "school",
                table: "department_support_staff",
                column: "departments_id",
                principalSchema: "school",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_support_staff_support_staffs_staff_id",
                schema: "school",
                table: "department_support_staff",
                column: "staff_id",
                principalSchema: "school",
                principalTable: "support_staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_teacher_departments_departments_id",
                schema: "school",
                table: "department_teacher",
                column: "departments_id",
                principalSchema: "school",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_support_staffs_schools_school_id",
                schema: "school",
                table: "support_staffs",
                column: "school_id",
                principalSchema: "school",
                principalTable: "schools",
                principalColumn: "school_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_department_support_staff_departments_departments_id",
                schema: "school",
                table: "department_support_staff");

            migrationBuilder.DropForeignKey(
                name: "fk_department_support_staff_support_staffs_staff_id",
                schema: "school",
                table: "department_support_staff");

            migrationBuilder.DropForeignKey(
                name: "fk_department_teacher_departments_departments_id",
                schema: "school",
                table: "department_teacher");

            migrationBuilder.DropForeignKey(
                name: "fk_support_staffs_schools_school_id",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "school");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "school");

            migrationBuilder.DropPrimaryKey(
                name: "pk_support_staffs",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropPrimaryKey(
                name: "pk_departments",
                schema: "school",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "city",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "country",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "national_id",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "other_names",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "street",
                schema: "school",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "school",
                table: "students");

            migrationBuilder.DropColumn(
                name: "city",
                schema: "school",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "country",
                schema: "school",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "school",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "other_names",
                schema: "school",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "street",
                schema: "school",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "city",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "country",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "national_id",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "other_names",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.DropColumn(
                name: "street",
                schema: "school",
                table: "support_staffs");

            migrationBuilder.RenameTable(
                name: "support_staffs",
                schema: "school",
                newName: "staff",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "departments",
                schema: "school",
                newName: "department",
                newSchema: "school");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "school",
                table: "teachers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "other_names",
                schema: "school",
                table: "students",
                newName: "region");

            migrationBuilder.RenameColumn(
                name: "national_id",
                schema: "school",
                table: "students",
                newName: "primary_phone");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "school",
                table: "students",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "school",
                table: "parents",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "school",
                table: "staff",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "ix_support_staffs_school_id",
                schema: "school",
                table: "staff",
                newName: "ix_staff_school_id");

            migrationBuilder.AlterColumn<int>(
                name: "teacher_id",
                schema: "school",
                table: "class_rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_staff",
                schema: "school",
                table: "staff",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_department",
                schema: "school",
                table: "department",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_class_rooms_teachers_teacher_id",
                schema: "school",
                table: "class_rooms",
                column: "teacher_id",
                principalSchema: "school",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_support_staff_department_departments_id",
                schema: "school",
                table: "department_support_staff",
                column: "departments_id",
                principalSchema: "school",
                principalTable: "department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_support_staff_staff_staff_id",
                schema: "school",
                table: "department_support_staff",
                column: "staff_id",
                principalSchema: "school",
                principalTable: "staff",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_teacher_department_departments_id",
                schema: "school",
                table: "department_teacher",
                column: "departments_id",
                principalSchema: "school",
                principalTable: "department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staff_schools_school_id",
                schema: "school",
                table: "staff",
                column: "school_id",
                principalSchema: "school",
                principalTable: "schools",
                principalColumn: "school_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
