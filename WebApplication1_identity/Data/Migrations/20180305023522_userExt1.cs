using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1_identity.Data.Migrations
{
    public partial class userExt1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Code = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    ParentCode = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Code);
                    //table.ForeignKey(
                    //    name: "FK_Team_Team_ParentCode",
                    //    column: x => x.ParentCode,
                    //    principalTable: "Team",
                    //    principalColumn: "Code",
                    //    onDelete: ReferentialAction.Cascade
                    //    );
                });
            //Error Code: 1452.Cannot add or update a child row: a foreign key constraint fails(`mydd`.`team`, CONSTRAINT `FK_Team_Team_ParentCode` FOREIGN KEY(`ParentCode`) REFERENCES `team` (`Code`) ON DELETE CASCADE)

            migrationBuilder.CreateTable(
                name: "UserExtend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BelongTeamId = table.Column<long>(nullable: false),
                    MyTags = table.Column<string>(nullable: true),
                    MyTeams = table.Column<string>(nullable: true),
                    MyTopic = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExtend_Team_BelongTeamId",
                        column: x => x.BelongTeamId,
                        principalTable: "Team",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ParentCode",
                table: "Team",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserExtend_BelongTeamId",
                table: "UserExtend",
                column: "BelongTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExtend");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
