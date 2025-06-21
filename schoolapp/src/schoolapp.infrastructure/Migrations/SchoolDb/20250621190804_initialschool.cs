using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations.SchoolDb
{
    /// <inheritdoc />
    public partial class initialschool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.EnsureSchema(
                name: "academics");

            migrationBuilder.EnsureSchema(
                name: "people");

            migrationBuilder.CreateTable(
                name: "academic_years",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_current = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_years", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    department_name = table.Column<string>(type: "text", nullable: false),
                    department_head = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    schoolname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    school_type = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    zip_code = table.Column<string>(type: "text", nullable: true),
                    postal_code = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    home_page = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "academic_terms",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_terms", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_terms_academic_years_academic_year_id",
                        column: x => x.academic_year_id,
                        principalSchema: "school",
                        principalTable: "academic_years",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    desc = table.Column<string>(type: "text", nullable: false),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    minimum_overall_grade_for_promotion = table.Column<double>(type: "double precision", nullable: false),
                    minimum_grade_per_compulsory_subject = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grades", x => x.id);
                    table.ForeignKey(
                        name: "fk_grades_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parents",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    other_names = table.Column<string>(type: "text", nullable: true),
                    national_id = table.Column<string>(type: "text", nullable: true),
                    salutation = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parents", x => x.id);
                    table.ForeignKey(
                        name: "fk_parents_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    is_group_of_schools = table.Column<bool>(type: "boolean", nullable: false),
                    use_streams = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school_settings", x => x.id);
                    table.ForeignKey(
                        name: "fk_school_settings_schools_parent_school_id",
                        column: x => x.parent_school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "support_staffs",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    staff_number = table.Column<string>(type: "text", nullable: true),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    designation = table.Column<string>(type: "text", nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    reg_no = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    other_names = table.Column<string>(type: "text", nullable: true),
                    national_id = table.Column<string>(type: "text", nullable: true),
                    salutation = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_support_staffs", x => x.id);
                    table.ForeignKey(
                        name: "fk_support_staffs_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<string>(type: "text", nullable: true),
                    reg_no = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    other_names = table.Column<string>(type: "text", nullable: true),
                    national_id = table.Column<string>(type: "text", nullable: true),
                    salutation = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    school_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.id);
                    table.ForeignKey(
                        name: "fk_teachers_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "fk_department_support_staff_departments_departments_id",
                        column: x => x.departments_id,
                        principalSchema: "school",
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_support_staff_support_staffs_staff_id",
                        column: x => x.staff_id,
                        principalSchema: "school",
                        principalTable: "support_staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class_rooms",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    grade_id = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_class_rooms", x => x.id);
                    table.ForeignKey(
                        name: "fk_class_rooms_grades_grade_id",
                        column: x => x.grade_id,
                        principalSchema: "school",
                        principalTable: "grades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_class_rooms_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalSchema: "school",
                        principalTable: "teachers",
                        principalColumn: "id");
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
                        name: "fk_department_teacher_departments_departments_id",
                        column: x => x.departments_id,
                        principalSchema: "school",
                        principalTable: "departments",
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

            migrationBuilder.CreateTable(
                name: "school_subjects",
                schema: "academics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    school_id = table.Column<int>(type: "integer", nullable: false),
                    subject_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    desc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    elective = table.Column<bool>(type: "boolean", nullable: false),
                    credit_hours = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_school_subjects_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_school_subjects_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalSchema: "school",
                        principalTable: "teachers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "people",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_number = table.Column<string>(type: "text", nullable: false),
                    class_room_id = table.Column<int>(type: "integer", nullable: true),
                    current_grade_id = table.Column<int>(type: "integer", nullable: true),
                    enrollment_year_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    graduation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    withdrawal_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    withdrawal_reason = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    last_modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    other_names = table.Column<string>(type: "text", nullable: true),
                    national_id = table.Column<string>(type: "text", nullable: true),
                    salutation = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    school_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_academic_years_enrollment_year_id",
                        column: x => x.enrollment_year_id,
                        principalSchema: "school",
                        principalTable: "academic_years",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_students_class_rooms_class_room_id",
                        column: x => x.class_room_id,
                        principalSchema: "school",
                        principalTable: "class_rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_students_grades_current_grade_id",
                        column: x => x.current_grade_id,
                        principalSchema: "school",
                        principalTable: "grades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_students_schools_school_id",
                        column: x => x.school_id,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classroom_subjects",
                schema: "academics",
                columns: table => new
                {
                    class_room_id = table.Column<int>(type: "integer", nullable: false),
                    school_subject_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    elective = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classroom_subjects", x => new { x.class_room_id, x.school_subject_id });
                    table.ForeignKey(
                        name: "fk_classroom_subjects_class_rooms_class_room_id",
                        column: x => x.class_room_id,
                        principalSchema: "school",
                        principalTable: "class_rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_classroom_subjects_school_subjects_school_subject_id",
                        column: x => x.school_subject_id,
                        principalSchema: "academics",
                        principalTable: "school_subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_record",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    grade_id = table.Column<int>(type: "integer", nullable: false),
                    class_room_id = table.Column<int>(type: "integer", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    overall_grade = table.Column<double>(type: "double precision", nullable: false),
                    completion_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    previous_grade_id = table.Column<int>(type: "integer", nullable: true),
                    new_grade_id = table.Column<int>(type: "integer", nullable: false),
                    promotion_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_record", x => x.id);
                    table.ForeignKey(
                        name: "fk_academic_record_academic_years_academic_year_id",
                        column: x => x.academic_year_id,
                        principalSchema: "school",
                        principalTable: "academic_years",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_record_class_rooms_class_room_id",
                        column: x => x.class_room_id,
                        principalSchema: "school",
                        principalTable: "class_rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_record_grades_grade_id",
                        column: x => x.grade_id,
                        principalSchema: "school",
                        principalTable: "grades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_record_grades_new_grade_id",
                        column: x => x.new_grade_id,
                        principalSchema: "school",
                        principalTable: "grades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_record_grades_previous_grade_id",
                        column: x => x.previous_grade_id,
                        principalSchema: "school",
                        principalTable: "grades",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_academic_record_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "people",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_parent",
                schema: "school",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    parent_id = table.Column<int>(type: "integer", nullable: false),
                    parent_type = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_parent", x => new { x.parent_id, x.student_id });
                    table.ForeignKey(
                        name: "fk_student_parent_parents_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "school",
                        principalTable: "parents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_parent_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "people",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    elective = table.Column<bool>(type: "boolean", nullable: false),
                    academic_year_id = table.Column<int>(type: "integer", nullable: false),
                    final_grade = table.Column<double>(type: "double precision", nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    withdrawal_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    withdrawal_reason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_subjects", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_subjects_academic_years_academic_year_id",
                        column: x => x.academic_year_id,
                        principalSchema: "school",
                        principalTable: "academic_years",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_subjects_school_subjects_subject_id",
                        column: x => x.subject_id,
                        principalSchema: "academics",
                        principalTable: "school_subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_subjects_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "people",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    student_subject_id = table.Column<int>(type: "integer", nullable: false),
                    grade = table.Column<double>(type: "double precision", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assessment", x => x.id);
                    table.ForeignKey(
                        name: "fk_assessment_student_subjects_student_subject_id",
                        column: x => x.student_subject_id,
                        principalSchema: "academics",
                        principalTable: "student_subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_academic_year_id",
                schema: "school",
                table: "academic_record",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_class_room_id",
                schema: "school",
                table: "academic_record",
                column: "class_room_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_grade_id",
                schema: "school",
                table: "academic_record",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_new_grade_id",
                schema: "school",
                table: "academic_record",
                column: "new_grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_previous_grade_id",
                schema: "school",
                table: "academic_record",
                column: "previous_grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_record_student_id",
                schema: "school",
                table: "academic_record",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_terms_academic_year_id",
                schema: "school",
                table: "academic_terms",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_assessment_student_subject_id",
                schema: "school",
                table: "assessment",
                column: "student_subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_class_rooms_grade_id",
                schema: "school",
                table: "class_rooms",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_class_rooms_teacher_id",
                schema: "school",
                table: "class_rooms",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "ix_classroom_subjects_school_subject_id",
                schema: "academics",
                table: "classroom_subjects",
                column: "school_subject_id");

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

            migrationBuilder.CreateIndex(
                name: "ix_grades_school_id",
                schema: "school",
                table: "grades",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_parents_school_id",
                schema: "school",
                table: "parents",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_school_settings_parent_school_id",
                schema: "school",
                table: "school_settings",
                column: "parent_school_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_school_subjects_school_id",
                schema: "academics",
                table: "school_subjects",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_school_subjects_teacher_id",
                schema: "academics",
                table: "school_subjects",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_parent_student_id",
                schema: "school",
                table: "student_parent",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subjects_academic_year_id",
                schema: "academics",
                table: "student_subjects",
                column: "academic_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subjects_student_id",
                schema: "academics",
                table: "student_subjects",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subjects_subject_id",
                schema: "academics",
                table: "student_subjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_class_room_id",
                schema: "people",
                table: "students",
                column: "class_room_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_current_grade_id",
                schema: "people",
                table: "students",
                column: "current_grade_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_enrollment_year_id",
                schema: "people",
                table: "students",
                column: "enrollment_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_students_school_id",
                schema: "people",
                table: "students",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_support_staffs_school_id",
                schema: "school",
                table: "support_staffs",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "ix_teachers_school_id",
                schema: "school",
                table: "teachers",
                column: "school_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academic_record",
                schema: "school");

            migrationBuilder.DropTable(
                name: "academic_terms",
                schema: "school");

            migrationBuilder.DropTable(
                name: "assessment",
                schema: "school");

            migrationBuilder.DropTable(
                name: "classroom_subjects",
                schema: "academics");

            migrationBuilder.DropTable(
                name: "department_support_staff",
                schema: "school");

            migrationBuilder.DropTable(
                name: "department_teacher",
                schema: "school");

            migrationBuilder.DropTable(
                name: "school_settings",
                schema: "school");

            migrationBuilder.DropTable(
                name: "student_parent",
                schema: "school");

            migrationBuilder.DropTable(
                name: "student_subjects",
                schema: "academics");

            migrationBuilder.DropTable(
                name: "support_staffs",
                schema: "school");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "school");

            migrationBuilder.DropTable(
                name: "parents",
                schema: "school");

            migrationBuilder.DropTable(
                name: "school_subjects",
                schema: "academics");

            migrationBuilder.DropTable(
                name: "students",
                schema: "people");

            migrationBuilder.DropTable(
                name: "academic_years",
                schema: "school");

            migrationBuilder.DropTable(
                name: "class_rooms",
                schema: "school");

            migrationBuilder.DropTable(
                name: "grades",
                schema: "school");

            migrationBuilder.DropTable(
                name: "teachers",
                schema: "school");

            migrationBuilder.DropTable(
                name: "schools",
                schema: "school");
        }
    }
}
