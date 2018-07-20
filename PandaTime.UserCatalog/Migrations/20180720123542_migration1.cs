using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PandaTime.UserCatalog.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    Personal = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Default = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    Activated = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(maxLength: 256, nullable: true),
                    LastName = table.Column<string>(maxLength: 256, nullable: true),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    GroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    GroupId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Text = table.Column<string>(maxLength: 1024, nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValueSql: "current_timestamp"),
                    PostId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 1024, nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CreatedAt", "Description", "LastModified", "Name", "Personal" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, true },
                    { 2, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, true },
                    { 3, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, true },
                    { 4, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, true },
                    { 5, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), null, true },
                    { 6, new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), "This is a public group", new DateTime(2018, 7, 20, 12, 35, 41, 739, DateTimeKind.Utc), "Public Group", false }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Code", "CreatedAt", "Default", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "en", new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), true, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "English" },
                    { 2, "sv", new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), false, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), "Admin" },
                    { 2, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), "Support" },
                    { 3, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), "Moderator" },
                    { 4, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Activated", "CreatedAt", "Email", "FirstName", "LanguageId", "LastModified", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "admin@forkyfork.com", "Admin", 1, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "User", "123" },
                    { 2, true, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "support@forkyfork.com", "Support", 1, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "User", "123" },
                    { 3, true, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "moderator@forkyfork.com", "Moderator", 1, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "User", "123" },
                    { 4, true, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "user1@forkyfork.com", "User", 1, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "Active", "123" },
                    { 5, false, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "user2@forkyfork.com", "User", 1, new DateTime(2018, 7, 20, 12, 35, 41, 741, DateTimeKind.Utc), "Inactive", "123" }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "CreatedAt", "GroupId", "LastModified", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 1, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 1, 1 },
                    { 2, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 2, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 2, 2 },
                    { 3, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 3, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 3, 3 },
                    { 4, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 4, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 4, 4 },
                    { 6, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 6, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 1, 4 },
                    { 5, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 5, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 4, 5 },
                    { 7, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 6, new DateTime(2018, 7, 20, 12, 35, 41, 742, DateTimeKind.Utc), 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_GroupId",
                table: "Membership",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_RoleId",
                table: "Membership",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserId",
                table: "Membership",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AuthorId",
                table: "Post",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupId",
                table: "Post",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LanguageId",
                table: "User",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
