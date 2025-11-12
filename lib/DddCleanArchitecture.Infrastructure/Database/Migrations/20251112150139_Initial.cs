using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DddCleanArchitecture.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentEntity_ArticleEntity_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ArticleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentEntity_ArticleId",
                table: "CommentEntity",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentEntity");

            migrationBuilder.DropTable(
                name: "ArticleEntity");
        }
    }
}
