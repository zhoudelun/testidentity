using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagId = table.Column<int>(nullable: true),
                    TeamCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamTag_Team_TeamCode",
                        column: x => x.TeamCode,
                        principalTable: "Team",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamCode = table.Column<long>(nullable: true),
                    TopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamTopic_Team_TeamCode",
                        column: x => x.TeamCode,
                        principalTable: "Team",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_TopicId",
                table: "Team",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTag_TagId",
                table: "TeamTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTag_TeamCode",
                table: "TeamTag",
                column: "TeamCode");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTopic_TeamCode",
                table: "TeamTopic",
                column: "TeamCode");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTopic_TopicId",
                table: "TeamTopic",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Topic_TopicId",
                table: "Team",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Topic_TopicId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "TeamTag");

            migrationBuilder.DropTable(
                name: "TeamTopic");

            migrationBuilder.DropIndex(
                name: "IX_Team_TopicId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Team");
        }
    }
}
