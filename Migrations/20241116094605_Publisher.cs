using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dordea_Voicu_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Book",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublisherName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherID",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublisherID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Book");
        }
    }
}
