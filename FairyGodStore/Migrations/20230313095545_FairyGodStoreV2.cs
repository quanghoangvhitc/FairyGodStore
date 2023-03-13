using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairyGodStore.Migrations
{
    /// <inheritdoc />
    public partial class FairyGodStoreV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "releasedate",
                table: "book",
                newName: "chapterdate");

            migrationBuilder.AlterColumn<long>(
                name: "releasedate",
                table: "bookcontent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chapter",
                table: "book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "publicationdate",
                table: "book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "chapter",
                table: "book");

            migrationBuilder.DropColumn(
                name: "publicationdate",
                table: "book");

            migrationBuilder.RenameColumn(
                name: "chapterdate",
                table: "book",
                newName: "releasedate");

            migrationBuilder.AlterColumn<string>(
                name: "releasedate",
                table: "bookcontent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
