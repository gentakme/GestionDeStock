using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDeStock.Migrations
{
    public partial class Change_PropName_CategorieId_To_CategorieType__Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AbpArticles");

            migrationBuilder.AddColumn<string>(
                name: "CategorieType",
                table: "AbpArticles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategorieType",
                table: "AbpArticles");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AbpArticles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
