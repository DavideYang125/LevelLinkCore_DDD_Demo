using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelLinkCore.Infrastructure.Migrations
{
    public partial class levelLink_add_citycount4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "city_count",
                table: "provinces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city_count",
                table: "provinces");
        }
    }
}
