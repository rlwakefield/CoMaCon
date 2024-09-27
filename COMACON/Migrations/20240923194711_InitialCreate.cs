using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMACON.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordPolicies",
                columns: table => new
                {
                    PswdPolicyId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PolicyType = table.Column<byte>(type: "INTEGER", nullable: false),
                    PolicyName = table.Column<string>(type: "TEXT", nullable: false),
                    PolicyDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PolicyEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordPolicies", x => x.PswdPolicyId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PermissionName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SystemTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatabaseVersion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTables", x => x.Id);
                    table.CheckConstraint("CK_SystemTable_Id", "[Id] = 1");
                });

            migrationBuilder.CreateTable(
                name: "PasswordRules",
                columns: table => new
                {
                    PswdRuleId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PswdPolicyId = table.Column<long>(type: "INTEGER", nullable: false),
                    RuleType = table.Column<byte>(type: "INTEGER", nullable: false),
                    RuleValue = table.Column<short>(type: "INTEGER", nullable: true),
                    RuleEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRules", x => x.PswdRuleId);
                    table.ForeignKey(
                        name: "FK_PasswordRules_PasswordPolicies_PswdPolicyId",
                        column: x => x.PswdPolicyId,
                        principalTable: "PasswordPolicies",
                        principalColumn: "PswdPolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleXPermissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleXPermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleXPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleXPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserNum = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordResetOnNextLogin = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordLastChanged = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AuthMethod = table.Column<byte>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastEditedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserNum);
                    table.ForeignKey(
                        name: "FK_UserAccounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserAccounts_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserAccounts",
                        principalColumn: "UserNum");
                    table.ForeignKey(
                        name: "FK_UserAccounts_UserAccounts_LastEditedBy",
                        column: x => x.LastEditedBy,
                        principalTable: "UserAccounts",
                        principalColumn: "UserNum");
                });

            migrationBuilder.CreateTable(
                name: "SecurityLogs",
                columns: table => new
                {
                    SecurityLogId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<short>(type: "INTEGER", nullable: false),
                    UserNum = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDescription = table.Column<string>(type: "TEXT", nullable: false),
                    AffectedUserNum = table.Column<int>(type: "INTEGER", nullable: true),
                    LogDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityLogs", x => x.SecurityLogId);
                    table.ForeignKey(
                        name: "FK_SecurityLogs_UserAccounts_AffectedUserNum",
                        column: x => x.AffectedUserNum,
                        principalTable: "UserAccounts",
                        principalColumn: "UserNum");
                    table.ForeignKey(
                        name: "FK_SecurityLogs_UserAccounts_UserNum",
                        column: x => x.UserNum,
                        principalTable: "UserAccounts",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    AccessToken = table.Column<string>(type: "TEXT", nullable: false),
                    TokenType = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.AccessToken);
                    table.ForeignKey(
                        name: "FK_Sessions_UserAccounts_UserNum",
                        column: x => x.UserNum,
                        principalTable: "UserAccounts",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordRules_PswdPolicyId",
                table: "PasswordRules",
                column: "PswdPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleXPermissions_RoleId",
                table: "RoleXPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityLogs_AffectedUserNum",
                table: "SecurityLogs",
                column: "AffectedUserNum");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityLogs_UserNum",
                table: "SecurityLogs",
                column: "UserNum");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserNum",
                table: "Sessions",
                column: "UserNum");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_CreatedBy",
                table: "UserAccounts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_LastEditedBy",
                table: "UserAccounts",
                column: "LastEditedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_RoleId",
                table: "UserAccounts",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordRules");

            migrationBuilder.DropTable(
                name: "RoleXPermissions");

            migrationBuilder.DropTable(
                name: "SecurityLogs");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "SystemTables");

            migrationBuilder.DropTable(
                name: "PasswordPolicies");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
