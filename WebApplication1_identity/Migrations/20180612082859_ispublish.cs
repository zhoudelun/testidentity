using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1_identity.Migrations
{
    public partial class ispublish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Topic",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Tag",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Info");
        }
    }
}
