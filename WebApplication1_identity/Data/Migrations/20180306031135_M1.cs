using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DDUserId = table.Column<int>(nullable: false),
                    DDUserId1 = table.Column<string>(nullable: true),
                    Socre = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_UserExtend_DDUserId1",
                        column: x => x.DDUserId1,
                        principalTable: "UserExtend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    DDUserId = table.Column<int>(nullable: false),
                    DDUserId1 = table.Column<string>(nullable: true),
                    Des = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_UserExtend_DDUserId1",
                        column: x => x.DDUserId1,
                        principalTable: "UserExtend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 100, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DDUserId = table.Column<int>(nullable: false),
                    DDUserId1 = table.Column<string>(nullable: true),
                    InfoStatus = table.Column<int>(nullable: false),
                    TagsId = table.Column<string>(nullable: true),
                    TeamsId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 20, nullable: true),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Info_UserExtend_DDUserId1",
                        column: x => x.DDUserId1,
                        principalTable: "UserExtend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Info_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicAudit",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicAudit", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_TopicAudit_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InfoId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoTag_Info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfoTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InfoId = table.Column<int>(nullable: false),
                    TeamCode = table.Column<long>(nullable: true),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoTeam_Info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoTeam_Team_TeamCode",
                        column: x => x.TeamCode,
                        principalTable: "Team",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Info_DDUserId1",
                table: "Info",
                column: "DDUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Info_TopicId",
                table: "Info",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTag_InfoId",
                table: "InfoTag",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTag_TagId",
                table: "InfoTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTeam_InfoId",
                table: "InfoTeam",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTeam_TeamCode",
                table: "InfoTeam",
                column: "TeamCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_DDUserId1",
                table: "Tag",
                column: "DDUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_DDUserId1",
                table: "Topic",
                column: "DDUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoTag");

            migrationBuilder.DropTable(
                name: "InfoTeam");

            migrationBuilder.DropTable(
                name: "TopicAudit");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
