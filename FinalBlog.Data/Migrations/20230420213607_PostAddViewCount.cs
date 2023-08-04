using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBlog.Data.Migrations
{
    public partial class PostAddViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Posts");
        }
    }
}
