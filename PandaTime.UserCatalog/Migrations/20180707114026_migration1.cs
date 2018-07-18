using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PandaTime.UserCatalog.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedAt", "Description", "LastModified", "Name", "Personal" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 7, 11, 40, 25, 772, DateTimeKind.Utc), null, new DateTime(2018, 7, 7, 11, 40, 25, 772, DateTimeKind.Utc), null, true },
                    { 2, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, true },
                    { 3, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, true },
                    { 4, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, true },
                    { 5, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, new DateTime(2018, 7, 7, 11, 40, 25, 773, DateTimeKind.Utc), null, true }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code", "CreatedAt", "Default", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "en", new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), true, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "English" },
                    { 2, "sv", new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), false, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), "Admin" },
                    { 2, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), "Support" },
                    { 3, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), "Moderator" },
                    { 4, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Activated", "CreatedAt", "Email", "FirstName", "LanguageId", "LastModified", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "admin@forkyfork.com", "Admin", 1, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "User", "123" },
                    { 2, true, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "support@forkyfork.com", "Support", 1, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "User", "123" },
                    { 3, true, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "moderator@forkyfork.com", "Moderator", 1, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "User", "123" },
                    { 4, true, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "user1@forkyfork.com", "User", 1, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "Active", "123" },
                    { 5, false, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "user2@forkyfork.com", "User", 1, new DateTime(2018, 7, 7, 11, 40, 25, 774, DateTimeKind.Utc), "Inactive", "123" }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "CreatedAt", "GroupId", "LastModified", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 1, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 1, 1 },
                    { 2, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 2, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 2, 2 },
                    { 3, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 3, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 3, 3 },
                    { 4, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 4, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 4, 4 },
                    { 5, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 5, new DateTime(2018, 7, 7, 11, 40, 25, 775, DateTimeKind.Utc), 4, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code", "CreatedAt", "Default", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "en", new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), true, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "English" },
                    { 2, "sv", new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), false, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "Admin" },
                    { 2, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "Support" },
                    { 3, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "Moderator" },
                    { 4, new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), new DateTime(2018, 7, 7, 11, 38, 30, 746, DateTimeKind.Utc), "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Activated", "CreatedAt", "Email", "FirstName", "LanguageId", "LastModified", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "admin@forkyfork.com", "Admin", 1, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "User", "123" },
                    { 2, true, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "support@forkyfork.com", "Support", 1, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "User", "123" },
                    { 3, true, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "moderator@forkyfork.com", "Moderator", 1, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "User", "123" },
                    { 4, true, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "user1@forkyfork.com", "User", 1, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "Active", "123" },
                    { 5, false, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "user2@forkyfork.com", "User", 1, new DateTime(2018, 7, 7, 11, 38, 30, 747, DateTimeKind.Utc), "Inactive", "123" }
                });
        }
    }
}
