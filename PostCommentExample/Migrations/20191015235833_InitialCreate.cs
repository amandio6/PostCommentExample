using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostCommentExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTitle = table.Column<string>(maxLength: 250, nullable: false),
                    sPost = table.Column<string>(maxLength: 2500, nullable: false),
                    sAuthor = table.Column<string>(maxLength: 150, nullable: false),
                    dtRegist = table.Column<DateTime>(nullable: false),
                    dtPost = table.Column<DateTime>(nullable: true),
                    bCommentEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtComment = table.Column<DateTime>(nullable: false),
                    dtPublish = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    sComment = table.Column<string>(maxLength: 1500, nullable: false),
                    sAuthor = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
