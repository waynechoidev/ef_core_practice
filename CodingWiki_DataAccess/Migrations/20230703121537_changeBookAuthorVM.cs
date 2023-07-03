using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeBookAuthorVM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMaps");

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id1 = table.Column<int>(type: "int", nullable: true),
                    Author_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_Author_Id1",
                        column: x => x.Author_Id1,
                        principalTable: "Authors",
                        principalColumn: "Author_Id");
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_Book_Id1",
                        column: x => x.Book_Id1,
                        principalTable: "Books",
                        principalColumn: "Book_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_Author_Id1",
                table: "BookAuthor",
                column: "Author_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_Book_Id1",
                table: "BookAuthor",
                column: "Book_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.CreateTable(
                name: "BookAuthorMaps",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id1 = table.Column<int>(type: "int", nullable: true),
                    Book_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMaps", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthorMaps_Authors_Author_Id1",
                        column: x => x.Author_Id1,
                        principalTable: "Authors",
                        principalColumn: "Author_Id");
                    table.ForeignKey(
                        name: "FK_BookAuthorMaps_Books_Book_Id1",
                        column: x => x.Book_Id1,
                        principalTable: "Books",
                        principalColumn: "Book_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMaps_Author_Id1",
                table: "BookAuthorMaps",
                column: "Author_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMaps_Book_Id1",
                table: "BookAuthorMaps",
                column: "Book_Id1");
        }
    }
}
