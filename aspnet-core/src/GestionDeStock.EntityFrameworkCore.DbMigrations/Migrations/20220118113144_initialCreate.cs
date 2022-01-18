using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDeStock.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpCommandes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ArticleId = table.Column<Guid>(nullable: false),
                    DateCommande = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpCommandes_AbpArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "AbpArticles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpCommandes_ArticleId",
                table: "AbpCommandes",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpCommandes");

            migrationBuilder.DropTable(
                name: "AbpArticles");
        }
    }
}
