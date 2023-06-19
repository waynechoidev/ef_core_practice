using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFleunt_Many_To_Many_Book_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Book_fluent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_fluent_Publisher_Id",
                table: "Book_fluent",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_fluent_Publisher_fluent_Publisher_Id",
                table: "Book_fluent",
                column: "Publisher_Id",
                principalTable: "Publisher_fluent",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_fluent_Publisher_fluent_Publisher_Id",
                table: "Book_fluent");

            migrationBuilder.DropIndex(
                name: "IX_Book_fluent_Publisher_Id",
                table: "Book_fluent");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Book_fluent");
        }
    }
}
