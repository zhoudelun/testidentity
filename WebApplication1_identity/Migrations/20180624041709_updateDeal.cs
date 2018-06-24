using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1_identity.Migrations
{
    public partial class updateDeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Status",
                table: "Deal",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Deal",
                nullable: false,
                oldClrType: typeof(sbyte));
        }
    }
}
