using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FairyGodStore.Migrations
{
    /// <inheritdoc />
    public partial class FairyGodStoreV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "linkdata",
                table: "book",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "linkdata",
                table: "book");
        }
    }
}
