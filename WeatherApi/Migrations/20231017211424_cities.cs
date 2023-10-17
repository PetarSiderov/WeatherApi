using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WeatherApi.Migrations
{
    public partial class cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "longtext", nullable: false),
                    city_ascii = table.Column<string>(type: "longtext", nullable: false),
                    lat = table.Column<double>(type: "double", nullable: false),
                    lng = table.Column<double>(type: "double", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false),
                    iso2 = table.Column<string>(type: "longtext", nullable: false),
                    iso3 = table.Column<string>(type: "longtext", nullable: false),
                    admin_name = table.Column<string>(type: "longtext", nullable: false),
                    capital = table.Column<string>(type: "longtext", nullable: false),
                    population = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
