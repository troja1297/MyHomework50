using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstMVC.Migrations
{
    public partial class AddCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: true),
                    CurrencyName = table.Column<string>(nullable: true),
                    CurrencyRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencieses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currencieses",
                columns: new[] { "Id", "CurrencyCode", "CurrencyName", "CurrencyRate" },
                values: new object[] { 1, "RUB", "Рубль", 57.0 });

            migrationBuilder.InsertData(
                table: "Currencieses",
                columns: new[] { "Id", "CurrencyCode", "CurrencyName", "CurrencyRate" },
                values: new object[] { 2, "KGS", "Сом", 68.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencieses");
        }
    }
}
