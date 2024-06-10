using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.CreateTable(
                name: "aspnetroles",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                schema: "school",
                columns: table => new
                {
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    schoolname = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "text", nullable: false),
                    Address_Country = table.Column<string>(type: "text", nullable: false),
                    Address_Region = table.Column<string>(type: "text", nullable: false),
                    Address_Phone = table.Column<string>(type: "text", nullable: false),
                    Address_Fax = table.Column<string>(type: "text", nullable: false),
                    homepage = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schools", x => x.schoolid);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroleclaims",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "school",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserclaims",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "school",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserlogins",
                schema: "school",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerkey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "school",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserroles",
                schema: "school",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "school",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "school",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                schema: "school",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalSchema: "school",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "examtypes",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    desc = table.Column<string>(type: "text", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_examtypes", x => x.id);
                    table.ForeignKey(
                        name: "fk_examtypes_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
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
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grades", x => x.id);
                    table.ForeignKey(
                        name: "fk_grades_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supportstaffs",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    staffid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_Region = table.Column<string>(type: "text", nullable: true),
                    Address_Phone = table.Column<string>(type: "text", nullable: true),
                    Address_Fax = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staff", x => x.id);
                    table.ForeignKey(
                        name: "fk_staff_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacherid = table.Column<int>(type: "integer", nullable: false),
                    regno = table.Column<string>(type: "text", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_Region = table.Column<string>(type: "text", nullable: true),
                    Address_Phone = table.Column<string>(type: "text", nullable: true),
                    Address_Fax = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.id);
                    table.ForeignKey(
                        name: "fk_teachers_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    examtypeid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exams", x => x.id);
                    table.ForeignKey(
                        name: "fk_exams_examtypes_examtypeid",
                        column: x => x.examtypeid,
                        principalSchema: "school",
                        principalTable: "examtypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exams_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classrooms",
                schema: "school",
                columns: table => new
                {
                    classroomid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gradeid = table.Column<int>(type: "integer", nullable: false),
                    teacherid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classrooms", x => x.classroomid);
                    table.ForeignKey(
                        name: "fk_classrooms_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_classrooms_teachers_teacherid",
                        column: x => x.teacherid,
                        principalSchema: "school",
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    regnumber = table.Column<string>(type: "text", nullable: false),
                    classroomid = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_Region = table.Column<string>(type: "text", nullable: true),
                    Address_Phone = table.Column<string>(type: "text", nullable: true),
                    Address_Fax = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                    table.ForeignKey(
                        name: "fk_students_classrooms_classroomid",
                        column: x => x.classroomid,
                        principalSchema: "school",
                        principalTable: "classrooms",
                        principalColumn: "classroomid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_students_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parents",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parentid = table.Column<int>(type: "integer", nullable: false),
                    studentid = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    createdbyuserid = table.Column<string>(type: "text", nullable: false),
                    lastmodified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lastmodifiedbyuserid = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_Region = table.Column<string>(type: "text", nullable: true),
                    Address_Phone = table.Column<string>(type: "text", nullable: true),
                    Address_Fax = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parents", x => x.id);
                    table.ForeignKey(
                        name: "fk_parents_schools_schoolid",
                        column: x => x.schoolid,
                        principalSchema: "school",
                        principalTable: "schools",
                        principalColumn: "schoolid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parents_students_studentid",
                        column: x => x.studentid,
                        principalSchema: "school",
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_aspnetroleclaims_roleid",
                schema: "school",
                table: "aspnetroleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "school",
                table: "aspnetroles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserclaims_userid",
                schema: "school",
                table: "aspnetuserclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserlogins_userid",
                schema: "school",
                table: "aspnetuserlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserroles_roleid",
                schema: "school",
                table: "aspnetuserroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "school",
                table: "aspnetusers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "school",
                table: "aspnetusers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_schoolid",
                schema: "school",
                table: "classrooms",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_teacherid",
                schema: "school",
                table: "classrooms",
                column: "teacherid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exams_examtypeid",
                schema: "school",
                table: "exams",
                column: "examtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_exams_schoolid",
                schema: "school",
                table: "exams",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_examtypes_schoolid",
                schema: "school",
                table: "examtypes",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_grades_schoolid",
                schema: "school",
                table: "grades",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_parents_schoolid",
                schema: "school",
                table: "parents",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_parents_studentid",
                schema: "school",
                table: "parents",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_students_classroomid",
                schema: "school",
                table: "students",
                column: "classroomid");

            migrationBuilder.CreateIndex(
                name: "IX_students_schoolid",
                schema: "school",
                table: "students",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_supportstaffs_schoolid",
                schema: "school",
                table: "supportstaffs",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_schoolid",
                schema: "school",
                table: "teachers",
                column: "schoolid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnetroleclaims",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetuserclaims",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetuserlogins",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetuserroles",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetusertokens",
                schema: "school");

            migrationBuilder.DropTable(
                name: "exams",
                schema: "school");

            migrationBuilder.DropTable(
                name: "grades",
                schema: "school");

            migrationBuilder.DropTable(
                name: "parents",
                schema: "school");

            migrationBuilder.DropTable(
                name: "supportstaffs",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetroles",
                schema: "school");

            migrationBuilder.DropTable(
                name: "aspnetusers",
                schema: "school");

            migrationBuilder.DropTable(
                name: "examtypes",
                schema: "school");

            migrationBuilder.DropTable(
                name: "students",
                schema: "school");

            migrationBuilder.DropTable(
                name: "classrooms",
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
