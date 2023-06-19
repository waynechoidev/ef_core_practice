using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fluent_ManyToMany_WIthMappingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropTable(
                name: "Fluent_AuthorFluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.AddColumn<int>(
                name: "Author_Id1",
                table: "BookAuthorMap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Book_Id1",
                table: "BookAuthorMap",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookAuthorMap_fluent",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMap_fluent", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_fluent_Author_fluent_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Author_fluent",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_fluent_Book_fluent_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book_fluent",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id1",
                table: "BookAuthorMap",
                column: "Author_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Book_Id1",
                table: "BookAuthorMap",
                column: "Book_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_fluent_Author_Id",
                table: "BookAuthorMap_fluent",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id1",
                table: "BookAuthorMap",
                column: "Author_Id1",
                principalTable: "Authors",
                principalColumn: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id1",
                table: "BookAuthorMap",
                column: "Book_Id1",
                principalTable: "Books",
                principalColumn: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropTable(
                name: "BookAuthorMap_fluent");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Book_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropColumn(
                name: "Author_Id1",
                table: "BookAuthorMap");

            migrationBuilder.DropColumn(
                name: "Book_Id1",
                table: "BookAuthorMap");

            migrationBuilder.CreateTable(
                name: "Fluent_AuthorFluent_Book",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksBook_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorFluent_Book", x => new { x.AuthorsAuthor_Id, x.BooksBook_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Author_fluent_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Author_fluent",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Book_fluent_BooksBook_Id",
                        column: x => x.BooksBook_Id,
                        principalTable: "Book_fluent",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorFluent_Book_BooksBook_Id",
                table: "Fluent_AuthorFluent_Book",
                column: "BooksBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
