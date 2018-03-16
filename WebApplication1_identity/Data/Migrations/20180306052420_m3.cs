using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_UserExtend_DDUserId1",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_UserExtend_DDUserId1",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_DDUserId1",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Info_DDUserId1",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "DDUserId1",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "DDUserId1",
                table: "Info");

            migrationBuilder.AlterColumn<string>(
                name: "DDUserId",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DDUserId",
                table: "Info",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tag_DDUserId",
                table: "Tag",
                column: "DDUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Info_DDUserId",
                table: "Info",
                column: "DDUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_UserExtend_DDUserId",
                table: "Info",
                column: "DDUserId",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_UserExtend_DDUserId",
                table: "Tag",
                column: "DDUserId",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_UserExtend_DDUserId",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_UserExtend_DDUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_DDUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Info_DDUserId",
                table: "Info");

            migrationBuilder.AlterColumn<int>(
                name: "DDUserId",
                table: "Tag",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDUserId1",
                table: "Tag",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DDUserId",
                table: "Info",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DDUserId1",
                table: "Info",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_DDUserId1",
                table: "Tag",
                column: "DDUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Info_DDUserId1",
                table: "Info",
                column: "DDUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_UserExtend_DDUserId1",
                table: "Info",
                column: "DDUserId1",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_UserExtend_DDUserId1",
                table: "Tag",
                column: "DDUserId1",
                principalTable: "UserExtend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
