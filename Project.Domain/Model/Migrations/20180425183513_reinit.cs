using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project.Domain.Model.Migrations
{
    public partial class reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Companys_CompanyId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Companies");

            migrationBuilder.RenameColumn(
                name: "answers",
                table: "Tasks",
                newName: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeopleLimit",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReceivedPoints = table.Column<double>(nullable: false),
                    Solution = table.Column<string>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company_Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    CompanyNotificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Notifications_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Notifications_CompanyNotifications_CompanyNotificationId",
                        column: x => x.CompanyNotificationId,
                        principalTable: "CompanyNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAndNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    UserNotificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAndNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAndNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAndNotifications_UserNotifications_UserNotificationId",
                        column: x => x.UserNotificationId,
                        principalTable: "UserNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Notifications_CompanyId",
                table: "Company_Notifications",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Notifications_CompanyNotificationId",
                table: "Company_Notifications",
                column: "CompanyNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAndNotifications_UserId",
                table: "CompanyAndNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAndNotifications_UserNotificationId",
                table: "CompanyAndNotifications",
                column: "UserNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_TaskId",
                table: "CompletedTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTasks_UserId",
                table: "CompletedTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Companies_CompanyId",
                table: "Courses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Companies_CompanyId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Company_Notifications");

            migrationBuilder.DropTable(
                name: "CompanyAndNotifications");

            migrationBuilder.DropTable(
                name: "CompletedTasks");

            migrationBuilder.DropTable(
                name: "CompanyNotifications");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PeopleLimit",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companys");

            migrationBuilder.RenameColumn(
                name: "Answers",
                table: "Tasks",
                newName: "answers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Companys_CompanyId",
                table: "Courses",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
