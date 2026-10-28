using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMVC.Migrations
{
    /// <inheritdoc />
    public partial class RenameBlogPostLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostLike_BlogPosts_BlogPostId",
                table: "blogPostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostLike",
                table: "blogPostLike");

            migrationBuilder.RenameTable(
                name: "blogPostLike",
                newName: "BlogPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostLike_BlogPostId",
                table: "BlogPostLike",
                newName: "IX_BlogPostLike_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostLike_BlogPosts_BlogPostId",
                table: "BlogPostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostLike",
                table: "BlogPostLike");

            migrationBuilder.RenameTable(
                name: "BlogPostLike",
                newName: "blogPostLike");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostLike_BlogPostId",
                table: "blogPostLike",
                newName: "IX_blogPostLike_BlogPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostLike",
                table: "blogPostLike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostLike_BlogPosts_BlogPostId",
                table: "blogPostLike",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
