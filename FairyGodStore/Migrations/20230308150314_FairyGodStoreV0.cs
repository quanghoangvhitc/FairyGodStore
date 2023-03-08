using Microsoft.EntityFrameworkCore.Migrations;

namespace FairyGodStore.Migrations
{
    public partial class FairyGodStoreV0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookcategory",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identitycard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    releasedate = table.Column<long>(type: "bigint", nullable: false),
                    thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sortdescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    views = table.Column<long>(type: "bigint", nullable: false),
                    point = table.Column<long>(type: "bigint", nullable: false),
                    bookCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                    table.ForeignKey(
                        name: "FK_book_bookcategory_bookCategoryId",
                        column: x => x.bookCategoryId,
                        principalTable: "bookcategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likecount = table.Column<long>(type: "bigint", nullable: false),
                    dislikecount = table.Column<long>(type: "bigint", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    parentid = table.Column<long>(type: "bigint", nullable: false),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookcomment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likecount = table.Column<long>(type: "bigint", nullable: false),
                    dislikecount = table.Column<long>(type: "bigint", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    parentid = table.Column<long>(type: "bigint", nullable: false),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcomment", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookcomment_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookcontent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    chapter = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    releasedate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcontent", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookcontent_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favorite",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorite", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorite_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorite_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    point = table.Column<double>(type: "float", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_rating_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookid = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: false),
                    modifiedby = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    modified = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.id);
                    table.ForeignKey(
                        name: "FK_report_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_report_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_bookCategoryId",
                table: "book",
                column: "bookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_bookcomment_bookid",
                table: "bookcomment",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_bookcontent_bookid",
                table: "bookcontent",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_comment_userid",
                table: "comment",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_favorite_bookid",
                table: "favorite",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_favorite_UserId",
                table: "favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_rating_bookid",
                table: "rating",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_userId",
                table: "rating",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_report_bookid",
                table: "report",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_report_UserId",
                table: "report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookcomment");

            migrationBuilder.DropTable(
                name: "bookcontent");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "favorite");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "bookcategory");
        }
    }
}
