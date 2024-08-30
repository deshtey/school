using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolapp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class lower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                schema: "school",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                schema: "school",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_tokens",
                schema: "school",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_users",
                schema: "school",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_roles",
                schema: "school",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_logins",
                schema: "school",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_claims",
                schema: "school",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_roles",
                schema: "school",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_role_claims",
                schema: "school",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "school",
                newName: "aspnetusertokens",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "school",
                newName: "aspnetusers",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "school",
                newName: "aspnetuserroles",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "school",
                newName: "aspnetuserlogins",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "school",
                newName: "aspnetuserclaims",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "school",
                newName: "aspnetroles",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "school",
                newName: "aspnetroleclaims",
                newSchema: "school");

            migrationBuilder.RenameIndex(
                name: "UserNameIndex",
                schema: "school",
                table: "aspnetusers",
                newName: "usernameindex");

            migrationBuilder.RenameIndex(
                name: "EmailIndex",
                schema: "school",
                table: "aspnetusers",
                newName: "emailindex");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_roles_role_id",
                schema: "school",
                table: "aspnetuserroles",
                newName: "ix_aspnetuserroles_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_logins_user_id",
                schema: "school",
                table: "aspnetuserlogins",
                newName: "ix_aspnetuserlogins_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_claims_user_id",
                schema: "school",
                table: "aspnetuserclaims",
                newName: "ix_aspnetuserclaims_user_id");

            migrationBuilder.RenameIndex(
                name: "RoleNameIndex",
                schema: "school",
                table: "aspnetroles",
                newName: "rolenameindex");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_role_claims_role_id",
                schema: "school",
                table: "aspnetroleclaims",
                newName: "ix_aspnetroleclaims_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusertokens",
                schema: "school",
                table: "aspnetusertokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetusers",
                schema: "school",
                table: "aspnetusers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserroles",
                schema: "school",
                table: "aspnetuserroles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserlogins",
                schema: "school",
                table: "aspnetuserlogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetuserclaims",
                schema: "school",
                table: "aspnetuserclaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroles",
                schema: "school",
                table: "aspnetroles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_aspnetroleclaims",
                schema: "school",
                table: "aspnetroleclaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_role_id",
                schema: "school",
                table: "aspnetroleclaims",
                column: "role_id",
                principalSchema: "school",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserclaims_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserclaims",
                column: "user_id",
                principalSchema: "school",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserlogins_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserlogins",
                column: "user_id",
                principalSchema: "school",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserroles",
                column: "user_id",
                principalSchema: "school",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_role_id",
                schema: "school",
                table: "aspnetuserroles",
                column: "role_id",
                principalSchema: "school",
                principalTable: "aspnetroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_aspnetusertokens_asp_net_users_user_id",
                schema: "school",
                table: "aspnetusertokens",
                column: "user_id",
                principalSchema: "school",
                principalTable: "aspnetusers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_aspnetroleclaims_aspnetroles_role_id",
                schema: "school",
                table: "aspnetroleclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserclaims_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserclaims");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserlogins_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserlogins");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_asp_net_users_user_id",
                schema: "school",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetuserroles_aspnetroles_role_id",
                schema: "school",
                table: "aspnetuserroles");

            migrationBuilder.DropForeignKey(
                name: "fk_aspnetusertokens_asp_net_users_user_id",
                schema: "school",
                table: "aspnetusertokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusertokens",
                schema: "school",
                table: "aspnetusertokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetusers",
                schema: "school",
                table: "aspnetusers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserroles",
                schema: "school",
                table: "aspnetuserroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserlogins",
                schema: "school",
                table: "aspnetuserlogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetuserclaims",
                schema: "school",
                table: "aspnetuserclaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroles",
                schema: "school",
                table: "aspnetroles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_aspnetroleclaims",
                schema: "school",
                table: "aspnetroleclaims");

            migrationBuilder.RenameTable(
                name: "aspnetusertokens",
                schema: "school",
                newName: "AspNetUserTokens",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetusers",
                schema: "school",
                newName: "AspNetUsers",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetuserroles",
                schema: "school",
                newName: "AspNetUserRoles",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetuserlogins",
                schema: "school",
                newName: "AspNetUserLogins",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetuserclaims",
                schema: "school",
                newName: "AspNetUserClaims",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetroles",
                schema: "school",
                newName: "AspNetRoles",
                newSchema: "school");

            migrationBuilder.RenameTable(
                name: "aspnetroleclaims",
                schema: "school",
                newName: "AspNetRoleClaims",
                newSchema: "school");

            migrationBuilder.RenameIndex(
                name: "usernameindex",
                schema: "school",
                table: "AspNetUsers",
                newName: "UserNameIndex");

            migrationBuilder.RenameIndex(
                name: "emailindex",
                schema: "school",
                table: "AspNetUsers",
                newName: "EmailIndex");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserroles_role_id",
                schema: "school",
                table: "AspNetUserRoles",
                newName: "ix_asp_net_user_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserlogins_user_id",
                schema: "school",
                table: "AspNetUserLogins",
                newName: "ix_asp_net_user_logins_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetuserclaims_user_id",
                schema: "school",
                table: "AspNetUserClaims",
                newName: "ix_asp_net_user_claims_user_id");

            migrationBuilder.RenameIndex(
                name: "rolenameindex",
                schema: "school",
                table: "AspNetRoles",
                newName: "RoleNameIndex");

            migrationBuilder.RenameIndex(
                name: "ix_aspnetroleclaims_role_id",
                schema: "school",
                table: "AspNetRoleClaims",
                newName: "ix_asp_net_role_claims_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_tokens",
                schema: "school",
                table: "AspNetUserTokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_users",
                schema: "school",
                table: "AspNetUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_roles",
                schema: "school",
                table: "AspNetUserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_logins",
                schema: "school",
                table: "AspNetUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_claims",
                schema: "school",
                table: "AspNetUserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_roles",
                schema: "school",
                table: "AspNetRoles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_role_claims",
                schema: "school",
                table: "AspNetRoleClaims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                schema: "school",
                table: "AspNetRoleClaims",
                column: "role_id",
                principalSchema: "school",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserClaims",
                column: "user_id",
                principalSchema: "school",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserLogins",
                column: "user_id",
                principalSchema: "school",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                schema: "school",
                table: "AspNetUserRoles",
                column: "role_id",
                principalSchema: "school",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserRoles",
                column: "user_id",
                principalSchema: "school",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                schema: "school",
                table: "AspNetUserTokens",
                column: "user_id",
                principalSchema: "school",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
