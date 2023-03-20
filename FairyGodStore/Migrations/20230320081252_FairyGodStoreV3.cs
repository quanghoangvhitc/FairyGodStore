using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairyGodStore.Migrations
{
    /// <inheritdoc />
    public partial class FairyGodStoreV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookcontent_book_bookid",
                table: "bookcontent");

            migrationBuilder.DropIndex(
                name: "IX_bookcontent_bookid",
                table: "bookcontent");

            migrationBuilder.DropColumn(
                name: "bookid",
                table: "bookcontent");

            migrationBuilder.DropColumn(
                name: "chapter",
                table: "bookcontent");

            migrationBuilder.RenameColumn(
                name: "releasedate",
                table: "bookcontent",
                newName: "bookchapterid");

            migrationBuilder.CreateTable(
                name: "bookchapter",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    chapter = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    modifiedby = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<long>(type: "bigint", nullable: true),
                    modified = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookchapter", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookchapter_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookcontent_bookchapterid",
                table: "bookcontent",
                column: "bookchapterid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookchapter_bookid",
                table: "bookchapter",
                column: "bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_bookcontent_bookchapter_bookchapterid",
                table: "bookcontent",
                column: "bookchapterid",
                principalTable: "bookchapter",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookcontent_bookchapter_bookchapterid",
                table: "bookcontent");

            migrationBuilder.DropTable(
                name: "bookchapter");

            migrationBuilder.DropIndex(
                name: "IX_bookcontent_bookchapterid",
                table: "bookcontent");

            migrationBuilder.RenameColumn(
                name: "bookchapterid",
                table: "bookcontent",
                newName: "releasedate");

            migrationBuilder.AddColumn<long>(
                name: "bookid",
                table: "bookcontent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "chapter",
                table: "bookcontent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookcontent_bookid",
                table: "bookcontent",
                column: "bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_bookcontent_book_bookid",
                table: "bookcontent",
                column: "bookid",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
