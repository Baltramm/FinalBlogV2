using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBlog.Data.Migrations
{
    public partial class AddTableUserToVisitedPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "UserToVisitedPost",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitedPostsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToVisitedPost", x => new { x.UsersId, x.VisitedPostsId });
                    table.ForeignKey(
                        name: "FK_UserToVisitedPost_Posts_VisitedPostsId",
                        column: x => x.VisitedPostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToVisitedPost_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToVisitedPost_VisitedPostsId",
                table: "UserToVisitedPost",
                column: "VisitedPostsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToVisitedPost");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
