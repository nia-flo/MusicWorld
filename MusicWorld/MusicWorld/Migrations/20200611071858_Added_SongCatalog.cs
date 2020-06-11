using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWorld.Migrations
{
    public partial class Added_SongCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongCatalogs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SongId = table.Column<string>(nullable: true),
                    CatalogId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongCatalogs_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongCatalogs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongCatalogs_CatalogId",
                table: "SongCatalogs",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_SongCatalogs_SongId",
                table: "SongCatalogs",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongCatalogs");
        }
    }
}
