using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_UserExtend_DDUserId1",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_DDUserId1",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "DDUserId1",
                table: "Topic");

            migrationBuilder.AlterColumn<string>(
                name: "DDUserId",
                table: "Topic",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "UserTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(nullable: true),
                    UserExtendId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTopic_UserExtend_UserExtendId",
                        column: x => x.UserExtendId,
                        principalTable: "UserExtend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_DDUserId",
                table: "Topic",
                column: "DDUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopic_TopicId",
                table: "UserTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopic_UserExtendId",
                table: "UserTopic",
                column: "UserExtendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_UserExtend_DDUserId",
                table: "Topic",
                column: "DDUserId",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_UserExtend_DDUserId",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "UserTopic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_DDUserId",
                table: "Topic");

            migrationBuilder.AlterColumn<int>(
                name: "DDUserId",
                table: "Topic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDUserId1",
                table: "Topic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_DDUserId1",
                table: "Topic",
                column: "DDUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_UserExtend_DDUserId1",
                table: "Topic",
                column: "DDUserId1",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
