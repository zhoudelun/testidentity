using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class codelong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTeam_Team_TeamCode",
                table: "InfoTeam");

            migrationBuilder.DropIndex(
                name: "IX_InfoTeam_TeamCode",
                table: "InfoTeam");

            migrationBuilder.DropColumn(
                name: "TeamCode",
                table: "InfoTeam");

            migrationBuilder.AlterColumn<long>(
                name: "TeamId",
                table: "InfoTeam",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_InfoTeam_TeamId",
                table: "InfoTeam",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTeam_Team_TeamId",
                table: "InfoTeam",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTeam_Team_TeamId",
                table: "InfoTeam");

            migrationBuilder.DropIndex(
                name: "IX_InfoTeam_TeamId",
                table: "InfoTeam");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "InfoTeam",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "TeamCode",
                table: "InfoTeam",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoTeam_TeamCode",
                table: "InfoTeam",
                column: "TeamCode");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTeam_Team_TeamCode",
                table: "InfoTeam",
                column: "TeamCode",
                principalTable: "Team",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
