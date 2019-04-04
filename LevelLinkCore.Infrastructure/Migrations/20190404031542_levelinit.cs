using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelLinkCore.Infrastructure.Migrations
{
    public partial class levelinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Population = table.Column<double>(nullable: false),
                    gdp_size = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "citys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProvinceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Unique = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Unique = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Unique = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city_info");

            migrationBuilder.DropTable(
                name: "citys");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
